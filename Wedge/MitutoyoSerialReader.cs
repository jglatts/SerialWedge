/**
 * 
 *     // simulated data on arduino 
 *     const char* frames[] = {
 *          "FFFF800247130", // -2.471 mm
 *          "FFFF000123450", // 0.01234 mm
 *          "FFFF800100000", // -1000 mm
 *          "FFFF000000100"  // 1 mm
 *     };
 * 
 *     parsing from UI: 
 *       -2.471mm     (correct)
 *       0.01234mm    (correct)
 *       -1000mm      (correct)
 *       1mm          (correct)
 */

using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wedgies
{
    public class MitutoyoSerialReader : SerialReaderBase
    {
        public MitutoyoSerialReader(SerialPort port, UpdateCallback callback)
            : base(port, callback)
        {
        }

        public override void initPort()
        {
            // set any custom port settings for the mitutoyo device here
            // example
            /*
            port.DataBits = 7;
            port.StopBits = StopBits.One;
            port.Parity = Parity.Even;
            */
        }

        public override PortSettings getPortSettings()
        {
            // create your own settings here for the mitutoyo device
            return base.getPortSettings();
        }

        public override bool worker()
        {
            try
            {
                if (!port.IsOpen)
                    return false;

                int[] frame = readMitutoyoFrame();
                if (frame == null || frame.Length != 13)
                    return false;

                if (!tryParseMitutoyoFrame(frame, out string formattedValue))
                    return false;

                formattedValue += "\n";
                SendKeys.SendWait(formattedValue);
                updateCallback?.Invoke(formattedValue);
                return true;
            }
            catch (Exception ex)
            {
                updateCallback?.Invoke("Mitutoyo parse error:\n" + ex.Message);
                return false;
            }
        }

        private int[] readMitutoyoFrame()
        {
            int[] data = new int[13];
            int index = 0;

            while (index < 13)
            {
                int raw = port.ReadByte();
                if (raw < 0)
                    return null;

                byte b = (byte)raw;

                // Skip common framing chars if present
                if (b == '\r' || b == '\n' || b == ' ' || b == '\t')
                    continue;

                // Support either:
                // 1) ASCII hex chars: 'F', '8', '0', etc.
                // 2) raw bytes where low nibble is the value
                if (isAsciiHex(b))
                {
                    data[index++] = hexCharToInt((char)b);
                }
                else
                {
                    data[index++] = b & 0x0F;
                }
            }

            return data;
        }

        private bool tryParseMitutoyoFrame(int[] d, out string result)
        {
            result = null;

            if (d.Length != 13)
                return false;

            // Header should be F F F F
            if (d[0] != 0xF || d[1] != 0xF || d[2] != 0xF || d[3] != 0xF)
                return false;

            // Sign: + = 0, - = 8
            bool isNegative = d[4] == 0x8;

            // Digits d6-d11
            var digitVals = d.Skip(5).Take(6).ToArray();
            if (digitVals.Any(x => x < 0 || x > 9))
                return false;

            string digits = string.Concat(digitVals.Select(x => x.ToString()));

            // Decimal position d12
            int decimalPlaces = decodeDecimalPlaces(d[11]);

            // Unit d13: 0 = mm, 1 = inch
            string unit = d[12] == 0x1 ? "inch" : "mm";

            string value = insertDecimal(digits, decimalPlaces);

            if (isNegative && value != "0")
                value = "-" + value;

            result = $"{value}{unit}";
            return true;
        }

        private int decodeDecimalPlaces(int value)
        {
            int decimalPlaces = 0;

            // Some devices send literal decimal count: 0–5
            if (value >= 0 && value <= 5)
                return value;

            switch (value)
            {
                case 0x8:
                    decimalPlaces = 1;
                    break;
                case 0x4:
                    decimalPlaces = 2;
                    break;
                case 0x2:
                    decimalPlaces = 3;
                    break;
                case 0x1:
                    decimalPlaces = 4;
                    break;
                default:
                    decimalPlaces = 0;
                    break;
            }

            return decimalPlaces;
        }

        private string insertDecimal(string digits, int decimalPlaces)
        {
            if (string.IsNullOrWhiteSpace(digits))
                return "0";

            digits = digits.TrimStart('0');

            if (digits.Length == 0)
                digits = "0";

            if (decimalPlaces <= 0)
                return digits;

            if (digits.Length <= decimalPlaces)
                digits = digits.PadLeft(decimalPlaces + 1, '0');

            int insertPos = digits.Length - decimalPlaces;
            string value = digits.Insert(insertPos, ".");

            if (value.StartsWith("."))
                value = "0" + value;

            // Optional cleanup: remove leading zeros except "0.xxx"
            if (value.Contains("."))
            {
                var parts = value.Split('.');
                parts[0] = parts[0].TrimStart('0');
                if (parts[0].Length == 0)
                    parts[0] = "0";
                value = parts[0] + "." + parts[1];
            }

            return value;
        }

        private bool isAsciiHex(byte b)
        {
            return
                (b >= (byte)'0' && b <= (byte)'9') ||
                (b >= (byte)'A' && b <= (byte)'F') ||
                (b >= (byte)'a' && b <= (byte)'f');
        }

        private int hexCharToInt(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';

            if (c >= 'A' && c <= 'F')
                return 10 + (c - 'A');

            if (c >= 'a' && c <= 'f')
                return 10 + (c - 'a');

            throw new ArgumentException("Invalid hex char: " + c);
        }
    }
}