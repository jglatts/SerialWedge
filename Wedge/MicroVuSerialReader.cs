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

        public MicroVuSerialReader(SerialPort port, UpdateCallback callback): 
            base(port, callback) 
        { 
            last_was_number = false;
        }

        public override void worker()
        {
            try
            {
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
}
