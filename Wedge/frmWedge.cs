using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Wedgies
{
    public partial class frmWedge : Form
    {
        private int[] bauds = {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200};
        private Dictionary<string, Handshake> handShakes = new Dictionary<string, Handshake>() 
        {
            { "None", Handshake.None },
            { "XOnXOff", Handshake.XOnXOff },
            { "ReqeustToSend", Handshake.RequestToSend },
            { "RequestToSendXOnXOff", Handshake.RequestToSendXOnXOff }

        };
        private bool bRunning = false;
        private SerialPort port = null;

        public frmWedge()
        {
            InitializeComponent();
            Populate();
            port = new SerialPort();
            port.ReadTimeout = 500;
            port.WriteTimeout = 500; 
            
            // event handlers
            chkOnOff.CheckedChanged += new EventHandler(chkOnOff_CheckedChanged);
            FormClosing += new FormClosingEventHandler(frmWedge_FormClosing);
            bgwInterceptWorker.DoWork += new DoWorkEventHandler(interceptBuffer);
            bgwInterceptWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StartStop);
        }

        void frmWedge_FormClosing(object sender, FormClosingEventArgs e)
        {
            chkOnOff.Checked = false;
        }

        void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (bRunning) bRunning = false; // this will will cause the Completed event to fire so we don't have to call StartStop here
            else StartStop(null, null); 
        }

        private void ToggleForm(bool enable)
        {
            cboBaudRate.Enabled = cboPort.Enabled = cboHandShake.Enabled = enable;
        }

        private void Populate()
        {
            cboPort.DataSource = SerialPort.GetPortNames();
            cboHandShake.DataSource = handShakes.Keys.ToArray();
            cboHandShake.SelectedIndex = 2;
            cboBaudRate.DataSource = bauds;
            cboBaudRate.SelectedIndex = 4;  
        }
        private void StartStop(object sender, RunWorkerCompletedEventArgs args)
        {
            ToggleForm(!chkOnOff.Checked);
            
            if (port.IsOpen) port.Close();
           
            if (chkOnOff.Checked)
            {
                try
                {
                    port.PortName = cboPort.SelectedItem + "";
                    port.BaudRate = (int)cboBaudRate.SelectedItem;
                    port.Handshake = handShakes[cboHandShake.SelectedItem.ToString()];
                    port.Open();
                    bRunning = true;
                    bgwInterceptWorker.RunWorkerAsync();
                }
                catch 
                {
                    MessageBox.Show("error opening port!");
                    chkOnOff.Checked = false;
                }
            }
        }
        private void interceptBuffer(object sender, DoWorkEventArgs args)
        {
            // below alg will get the 2nd val sent (the ydata)
            // should allow user to change this at run time 
            bool last_was_number = false; 

            while (bRunning)
            {
                try
                {
                    var line = port.ReadLine();
                    if (line.Contains("@"))
                        continue;

                    if (Double.TryParse(line, out double val))
                    {
                        if (val == 0)
                        {
                            continue;
                        }

                        if (last_was_number)
                        {
                            SendKeys.SendWait(line);
                            last_was_number = false;
                        }
                        else
                        {
                            last_was_number = true;
                        }
                    }

                }
                catch (TimeoutException) { }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
