﻿using System;
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
        private int[] bauds = {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200};
        private Dictionary<string, Handshake> handShakes = new Dictionary<string, Handshake>() 
        {
            { "None", Handshake.None },
            { "XOnXOff", Handshake.XOnXOff },
            { "RequestToSend", Handshake.RequestToSend },
            { "RequestToSendXOnXOff", Handshake.RequestToSendXOnXOff }

        };
        private bool bRunning = false;
        private SerialPort port = null;
        private bool inputBeep = false;

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
            chkBeepOnInput.Checked = true;
        }

        void frmWedge_FormClosing(object sender, FormClosingEventArgs e)
        {
            chkOnOff.Checked = false;
        }

        void chkOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (bRunning)
            {
                bRunning = false;
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

        private void updateLiveInput(string line)
        { 
            txtBoxLiveInput.Text += DateTime.Now.ToString("M/d/y h:mm:ss tt") + ">> " + line + "\n";
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
                    string line = port.ReadLine();

                    if (line.Contains("@"))
                        continue;

                    updateLiveInput(line);
                    if (Double.TryParse(line, out double val))
                    {
                        if (val == 0)
                        {
                            continue;
                        }

                        if (last_was_number)
                        {
                            SendKeys.SendWait(line);
                            if (inputBeep)
                            {
                                // bottleneck when calling Beep.Play()
                                // this is running in a bkgrd worker
                                //SystemSounds.Beep.Play();
                            }
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
            // this method will call StartStop() once complete
            // we set the RunWorkerCompleted property to StartStop in ctor 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkBeepOnInput_CheckedChanged(object sender, EventArgs e)
        {
            inputBeep = chkBeepOnInput.Checked;
        }
    }
}
