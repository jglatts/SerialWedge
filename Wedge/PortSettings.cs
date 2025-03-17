using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedgies
{
    public class PortSettings
    {
        public static Dictionary<string, Handshake> handShakes = new Dictionary<string, Handshake>()
        {
            { "None", Handshake.None },
            { "XOnXOff", Handshake.XOnXOff },
            { "RequestToSend", Handshake.RequestToSend },
            { "RequestToSendXOnXOff", Handshake.RequestToSendXOnXOff }

        };

        public static int[] bauds = { 110, 300, 600, 1200, 2400, 4800, 9600,
                                      14400, 19200, 38400, 57600, 115200 };

        public string handshake;
        public int baud;

        public PortSettings(string handshake, int baud)
        {
            bool found = false;
            string[] keys = handShakes.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                if (handshake.Equals(keys[i]))
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                handshake = "None";
            }

            this.handshake = handshake;
            this.baud = baud;
        }

        public PortSettings()
        {
            this.handshake = "";
            this.baud = -1;
        }
    }
}
