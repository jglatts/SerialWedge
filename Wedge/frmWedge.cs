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
using System.Media;

namespace Wedgies
{
    public partial class frmWedge : Form
    {
        private SerialPort port = null;
        private SerialReaderBase serialreader; 
        private Dictionary<string, Handshake> handShakes = new Dictionary<string, Handshake>() 
        {
            { "None", Handshake.None },
            { "XOnXOff", Handshake.XOnXOff },
            { "RequestToSend", Handshake.RequestToSend },
            { "RequestToSendXOnXOff", Handshake.RequestToSendXOnXOff }

        };
        private int[] bauds = { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200 };
        private bool inputBeep = false;

        public frmWedge()
        {
            InitializeComponent();
            Populate();

            // set the serial port
            port = new SerialPort();
            port.WriteTimeout = 500;
            port.ReadTimeout = 500;
            
            // set the serial reader implementation 
            serialreader = new IndicatorSerialReader(port, updateLiveInput);
            
            // MircoVu serial reader immplementation
            //serialreader = new MicroVuSerialReader(port, updateLiveInput);
            
            // default serial reader 
            //serialreader = new SerialReaderBase(port, updateLiveInput);
            
            // event handlers
            chkOnOff.CheckedChanged += new EventHandler(chkOnOff_CheckedChanged);
            FormClosing += new FormClosingEventHandler(frmWedge_FormClosing);
            bgwInterceptWorker.DoWork += new DoWorkEventHandler(serialreader.runner);
            bgwInterceptWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StartStop);
            chkBeepOnInput.Checked = true;
        }

        void frmWedge_FormClosing(object sender, FormClosingEventArgs e)
        {
            chkOnOff.Checked = false;
        }

        void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (serialreader.is_running)
            {
                serialreader.is_running = false;
                txtBoxLiveInput.Text = "";
            }
            else
            {
                StartStop(null, null);
            }
        }

        private void ToggleForm(bool enable)
        {
            cboBaudRate.Enabled = cboPort.Enabled = cboHandShake.Enabled = enable;
        }

        private void Populate()
        {
            string[] port_names = SerialPort.GetPortNames();
            if (port_names.Length != 0)
                cboPort.DataSource = port_names;
            else
                cboPort.Text = "NO PORTS FOUND";
            
            cboHandShake.DataSource = handShakes.Keys.ToArray();
            cboHandShake.SelectedIndex = 1;
            cboBaudRate.DataSource = bauds;
            cboBaudRate.SelectedIndex = 4;  
        }

        private void setAndOpenPort()
        {
            port.PortName = cboPort.SelectedItem + "";
            port.BaudRate = (int)cboBaudRate.SelectedItem;
            port.Handshake = handShakes[cboHandShake.SelectedItem.ToString()];
            port.RtsEnable = false;
            port.DtrEnable = true; // needed for xonxoff
            port.DataBits = 7;
            port.StopBits = StopBits.One;
            port.Parity = Parity.Even;
            port.Open();
        }

        private void StartStop(object sender, RunWorkerCompletedEventArgs args)
        {
            ToggleForm(!chkOnOff.Checked);
            
            if (port.IsOpen) port.Close();

            if (chkOnOff.Checked)
            {
                try
                {
                    setAndOpenPort();
                    serialreader.is_running = true;
                    bgwInterceptWorker.RunWorkerAsync();
                }
                catch
                {
                    MessageBox.Show("error opening port!");
                    chkOnOff.Checked = false;
                }
            }
        }
        private void updateLiveInput(string line)
        { 
            txtBoxLiveInput.Text += DateTime.Now.ToString("M/d/y h:mm:ss tt") + ">> " + line + "\n";
        }

        private void chkBeepOnInput_CheckedChanged(object sender, EventArgs e)
        {
            inputBeep = chkBeepOnInput.Checked;
        }
    }
}
