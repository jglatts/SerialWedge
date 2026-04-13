using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedgies;

namespace Wedgies
{
    public class MitutoyoSerialReader : SerialReaderBase
    {
        public MitutoyoSerialReader(SerialPort port, UpdateCallback callback) : 
            base(port, callback)
        {
        }

    }
}
