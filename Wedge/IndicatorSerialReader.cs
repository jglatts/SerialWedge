using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    class IndicatorSerialReader : SerialReaderBase
    {
        public IndicatorSerialReader(SerialPort port, UpdateCallback callback) : 
            base(port, callback)
        {
            this.port = port;
        }


        public override void worker() 
        {
            try
            {
                string line = port.ReadLine().Replace('?', ' ');
                string formatted_line = "";
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ' && line[i] != 'i' && line[i] != 'n')
                        formatted_line += line[i];
                }
                SendKeys.SendWait(formatted_line);
                updateCallback?.Invoke(formatted_line);
            }
            catch (TimeoutException)
            {
            }

        }
    
    }
}
