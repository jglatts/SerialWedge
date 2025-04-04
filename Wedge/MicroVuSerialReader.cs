using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wedgies
{
    class MicroVuSerialReader : SerialReaderBase
    {
        private bool get_x_data;
        private bool get_y_data;
        private bool get_xy_data;
        private frmWedge mainForm;
        private List<double> all_data;
        private string delim;

        // micro vu = REQUESTTOSEND

        public MicroVuSerialReader(SerialPort port, UpdateCallback callback): 
            base(port, callback) 
        {
            get_x_data = false;
            get_y_data = false;
            get_xy_data = false;
            all_data = new List<double>();
            delim = " ";
        }

        public void setForm(frmWedge form)
        {
            mainForm = form;
        }

        private bool getOutType()
        {
            bool ret = false;

            if (mainForm.chkGetXData.Checked && mainForm.chkGetYData.Checked)
            {
                get_xy_data = true;
                get_y_data = false;
                get_x_data = false;
                ret = true;
            }
            else if (mainForm.chkGetXData.Checked)
            {
                get_x_data = true;
                get_xy_data = false;
                get_y_data = false;
                ret = true; 
            }
            else if (mainForm.chkGetYData.Checked)
            { 
                get_y_data = true;
                get_x_data = false;
                get_xy_data = false;
                ret = true;
            }

            delim = mainForm.btnTabDelim.Checked ? "\t" : "\r\n";

            return ret;
        }

        public override PortSettings getPortSettings()
        {
            return new PortSettings("RequestToSend", 2400);
        }

        public override bool worker()
        {
            bool ret = true;    
            try
            {
                if (!getOutType())
                {
                    MessageBox.Show("error with data output type!\nplease see data-filterting tab");
                    return false;
                }

                string line = port.ReadLine();
                if (line.Contains("@"))
                    return false;
                
                if (Double.TryParse(line, out double val))
                {
                    all_data.Add(val);
                    if (all_data.Count == 3)
                    {
                        string data_str = "";
                        
                        if (get_xy_data)
                            data_str = all_data[0] + delim + all_data[1] + delim;
                        else if (get_y_data)
                            data_str = all_data[1] + delim;
                        else if (get_x_data)
                            data_str = all_data[0] + delim;
                        
                        SendKeys.SendWait(data_str);
                        //updateCallback?.Invoke(data_str);
                        all_data.Clear();   
                    }
                }

            }
            catch (TimeoutException) 
            {
                ret = false;
            }
            return ret;
        }

    }
}
