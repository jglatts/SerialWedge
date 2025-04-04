using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Media;
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
        private SoundPlayer soundPlayer;
        public bool is_running;
        private bool input_beep;

        public SerialReaderBase(SerialPort port, UpdateCallback updateCallback)
        {
            this.port = port;
            this.updateCallback = updateCallback;
            this.is_running = false;
            this.input_beep = false;
            this.soundPlayer = new SoundPlayer();
        }

        /*
         * default SerialPort init method
         * 
         * override this method to set custom
         * serial port parameters
         * i.e:
         *      port.RtsEnable = true;
         *
         */
        public virtual void initPort()
        {

        }

        /*
         *  default port settings
         *  
         *  this will load the GUI on startup with impl. specfic port details
         *  override this to implement your own
         */
        public virtual PortSettings getPortSettings()
        { 
            return new PortSettings("None", 115200);
        }

        public void setInputBeep(bool input_beep)
        { 
            this.input_beep = input_beep;
        }

        /*
         *  default serial keyboard implementation
         *  
         *  to impmeplent a custom serial reader wedge:
         *      - make a subclass of this class (SerialReaderBase)
         *      - implement a worker() method that will read and interpret your data 
         */
        public virtual bool worker() 
        {
            bool ret = true;
            try
            {
                string line = port.ReadLine();
                SendKeys.SendWait(line);
                updateCallback?.Invoke(line);
            }
            catch (TimeoutException) 
            {
                ret = false;
            }
            return ret;
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
                if (worker())
                {
                    if (input_beep)
                        SystemSounds.Beep.Play();
                }
            }
        }

    }
}
