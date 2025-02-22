using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wedgies
{
    class SerialReaderBase
    {
        public delegate void UpdateCallback(string s);

        public UpdateCallback updateCallback;
        public SerialPort port;
        public bool is_running;

        public SerialReaderBase(SerialPort port, UpdateCallback updateCallback)
        { 
            this.port = port;
            this.updateCallback = updateCallback;
            this.is_running = false;
        }

        public virtual void worker() 
        {
            string line = port.ReadLine();
            SendKeys.SendWait(line);
            updateCallback?.Invoke(line);
        }

        public void runner(object sender, DoWorkEventArgs args)
        {
            while (is_running)
            { 
                worker();
            }
        }

    }
}
