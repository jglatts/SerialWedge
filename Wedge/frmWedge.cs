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
        private int[] bauds = {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600};
        private bool bRunning = false;
        private SerialPort port = null;

        public frmWedge()
        {
            InitializeComponent();

            Populate();

            port = new SerialPort();
            port.ReadTimeout = 500;
            port.WriteTimeout = 500; 

            //handle events
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
            if (bRunning)bRunning = false; // this will will cause the Completed event to fire so we don't have to call StartStop here
            else StartStop(null, null); 
        }

        private void ToggleForm(bool enable)
        {
            cboBaudRate.Enabled = cboPort.Enabled = enable;
        }

        private void Populate()
        {
            cboPort.DataSource = SerialPort.GetPortNames();
            cboBaudRate.DataSource = bauds;
        }
        private void StartStop(object sender, RunWorkerCompletedEventArgs args)
        {
            ToggleForm(!chkOnOff.Checked);
            
            if (port.IsOpen) port.Close();
           
            if (chkOnOff.Checked)
            {
                port.PortName = cboPort.SelectedItem + "";
                port.BaudRate = (int)cboBaudRate.SelectedItem;
                port.Handshake = Handshake.RequestToSend;
                port.Open();
                
                bRunning = true;
                bgwInterceptWorker.RunWorkerAsync();
            }
        }
        private void interceptBuffer(object sender, DoWorkEventArgs args)
        {
            string last_string = "";
            while (bRunning)
            {
                try
                {
                    var line = port.ReadLine();
                    if (line.Contains("@"))
                        continue;

                    SendKeys.SendWait(line);
                }
                catch (TimeoutException) { }
            }
        }

    }
}
