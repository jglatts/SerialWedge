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
    public class SerialReaderBase
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

        /*
         * default SerialPort settings 
         * 
         * override this method to set custom
         * serial port settings 
         * i.e:
         *      port.RtsEnable = true;
         *
         */
        public virtual void initPort()
        {

        }

        /*
         *  default serial keyboard implementation
         *  
         *  to impmeplent a custom serial reader wedge:
         *      - make a subclass of this class (SerialReaderBase)
         *      - implement a worker() method that will read and interpret your data 
         */
        public virtual void worker() 
        {
            try
            {
                string line = port.ReadLine();
                SendKeys.SendWait(line);
                updateCallback?.Invoke(line);
            }
            catch (TimeoutException) { }
        }

        public void runner(object sender, DoWorkEventArgs args)
        {
            if (!port.IsOpen)
            { 
                updateCallback?.Invoke("error!\nserial port not open!");
                return;
            }

            while (is_running)
            { 
                worker();
            }
        }

    }
}
