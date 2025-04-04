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
        public string handshake;
        public int baud;

        public static Dictionary<string, Handshake> handShakes = new Dictionary<string, Handshake>()
        {
            { "None", Handshake.None },
            { "XOnXOff", Handshake.XOnXOff },
            { "RequestToSend", Handshake.RequestToSend },
            { "RequestToSendXOnXOff", Handshake.RequestToSendXOnXOff }

        };

        public static int[] bauds = { 110, 300, 600, 1200, 2400, 4800, 9600,
                                      14400, 19200, 38400, 57600, 115200 };

        // change this to take the enum
        public PortSettings(string handshake, int baud)
        {
            string[] check = handShakes.Keys.ToArray().Where(k => (k == handshake)).ToArray();
            int[] baud_check = bauds.Where(b => (b == baud)).ToArray();
            this.handshake = check.Length > 0 ? handshake : "None";
            this.baud = baud_check.Length > 0 ? baud : 9600;
        }

        public PortSettings()
        {
            this.handshake = "";
            this.baud = -1;
        }
    }
}
