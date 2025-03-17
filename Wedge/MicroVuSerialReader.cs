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
        private bool last_was_number;
        private bool get_x_data;
        private bool get_y_data;
        private bool get_xy_data;
        private frmWedge mainForm;
        private List<double> xy_data;

        public MicroVuSerialReader(SerialPort port, UpdateCallback callback): 
            base(port, callback) 
        {
            last_was_number = false;
            get_x_data = false;
            get_y_data = false;
            get_xy_data = false;
            xy_data = new List<double>();
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
                ret = true;
            }
            else if (mainForm.chkGetXData.Checked)
            {
                get_x_data = true;
                ret = true; 
            }
            else if (mainForm.chkGetYData.Checked)
            { 
                get_y_data = true;
                ret = true;
            }

            return ret;
        }

        public override void worker()
        {
            try
            {
                if (!getOutType())
                {
                    MessageBox.Show("error with data output type!\nplease see data-filterting tab");
                    return;
                }

                string line = port.ReadLine();

                if (line.Contains("@"))
                    return;

                updateCallback?.Invoke(line);
                if (Double.TryParse(line, out double val))
                {
                    if (val == 0)
                    {
                        return;
                    }

                    if (get_y_data)
                    {
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
                    else if (get_x_data)
                    {
                        if (!last_was_number)
                        {
                            SendKeys.SendWait(line);
                            last_was_number = true;
                        }
                        else
                        {
                            last_was_number = false;
                        }
                    }
                    else if (get_xy_data)
                    {
                        xy_data.Add(val);
                        if (xy_data.Count == 2)
                        {
                            // will need to use either tabs or newline
                            // to get correct output in excel
                            string s = xy_data[0] + "\t" + xy_data[1] + "\t";
                            SendKeys.SendWait(line);
                            xy_data.Clear();
                        }
                    }
                }

            }
            catch (TimeoutException) { }
        }

    }
}
