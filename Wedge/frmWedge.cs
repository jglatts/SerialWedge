/*
 *       Serial Data Keyboard Wedge
 *       
 *       Sends serial port data to any application (e.g., Excel, Notepad, ERP systems).
 *       Can collect data from Serial, RS232, and RS232-via-USB industrial equipment.
 *       Supports real-time data viewing and custom data handling.
 *
 *        Features:
 *           Sends serial data as keyboard input
 *           Works with RS232, USB-to-Serial devices, and industrial equipment
 *           Real-time data viewing for monitoring incoming data
 *           Customizable serial data processing via SerialReaderBase
 *           Supports multiple baud rates and handshake methods 
 *           
 *       ToDo:
 *          Add data filtering options
 *          
 */
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

            // todo:
            //  move these constructors to the impl class and have a
            //  a static factory method to get the new SerialReader object

            // set the serial reader implementation 
            //setSerialReader(new IndicatorSerialReader(port, updateLiveInput));

            // MircoVu serial reader implementation
            MicroVuSerialReader microVu = new MicroVuSerialReader(port, updateLiveInput);
            chkGetXData.Checked = true;
            microVu.setForm(this);
            setSerialReader(microVu);

            // default serial reader 
            //setSerialReader(new SerialReaderBase(port, updateLiveInput));

            // event handlers
            chkOnOff.CheckedChanged += new EventHandler(chkOnOff_CheckedChanged);
            FormClosing += new FormClosingEventHandler(frmWedge_FormClosing);
            bgwInterceptWorker.DoWork += new DoWorkEventHandler(serialreader.runner);
            bgwInterceptWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(StartStop);
            chkBeepOnInput.Checked = true;
        }

        public void setSerialReader(SerialReaderBase serialReaderImpl)
        {
            serialreader = serialReaderImpl;
        }

        private void frmWedge_FormClosing(object sender, FormClosingEventArgs e)
        {
            chkOnOff.Checked = false;
        }

        private void chkOnOff_CheckedChanged(object sender, EventArgs e)
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
            serialreader.initPort();
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
