
# Simple Serial Data Keyboard Wedge

Sends serial port data to any application (e.g., Excel, Notepad, ERP systems).  
Can collect data from **Serial, RS232, and RS232-via-USB** industrial equipment.  
Supports **real-time data viewing** and **custom data handling**.  

## 🚀 Features  
✅ Sends serial data as **keyboard input**  
✅ Works with **RS232, USB-to-Serial devices, and industrial equipment**  
✅ **Real-time data viewing** for monitoring incoming data  
✅ **Customizable serial data processing** via `SerialReaderBase`  
✅ Supports **multiple baud rates and handshake methods**  

---

## 🔧 Compatible Devices  

| Device Type       | Examples |
|------------------|-----------------------------------|
| **Barcode Readers**  | Handheld scanners, POS systems  |
| **Weighing Scales**  | Industrial balances, lab scales |
| **Meters**          | Voltage meters, pressure gauges  |
| **Calipers**         | Digital calipers, micrometers   |
| **Sensors**          | Temperature, force, pH sensors  |
| **Custom Devices**   | Any RS232-based industrial tool |

Builds upon https://github.com/pormiston/SerialWedge

## System Screenshot
![system_gui](https://raw.githubusercontent.com/jglatts/SerialWedge/refs/heads/master/images/gui2.png)


## How To Run
### From Source
1. Clone the repo
2. Open the Wedge.sln solution file in Visual Studio
3. Build and Run 

### From Github Releases 
1. Dowload the assests from the releases tab
2. Run the Wedge.exe application 




## Creating a Custom Serial Reader for the Keyboard Wedge  

To implement a **custom serial reader**, follow these steps:  

### 1. Create a New Class that Inherits `SerialReaderBase`  
Your custom serial reader must be a **subclass of `SerialReaderBase`**.  
This ensures it integrates smoothly with the wedge system.  

#### Example: Creating `MyDeviceSerialReader`  
```csharp
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Wedgies
{
    class MyDeviceSerialReader : SerialReaderBase
    {
        public MyDeviceSerialReader(SerialPort port, UpdateCallback callback)
            : base(port, callback)
        {
        }

        public override void initPort()
        {
            // Configure serial port settings specific to your device
            port.Parity = Parity.Even;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.DtrEnable = true;
            port.RtsEnable = false;
        }

        public override void worker()
        {
            try
            {
                // Read a line of data from the serial port
                string line = port.ReadLine();

                // Process the data as needed
                if (string.IsNullOrEmpty(line))
                    return;

                // Example: Filter out unwanted characters
                line = line.Replace("?", "");

                // Send the processed data as keyboard input
                SendKeys.SendWait(line);

                // Invoke the callback to update UI or logs
                updateCallback?.Invoke(line);
            }
            catch (TimeoutException)
            {
                // No data available, continue
            }
        }
    }
}
```


### 2. Instantiate and Use Your Custom Reader  
In `frmwedge.cs`, you would typically instantiate your reader like this:  
```csharp
public frmWedge()
{
    // constructor code

    SerialPort port = new SerialPort();
    serialReader = new MyDeviceSerialReader(port, updateLiveInput);

    // more constructor code     
}
```


## Why This Is Effective  
![funny_img](https://raw.githubusercontent.com/jglatts/SerialWedge/refs/heads/master/images/funny-c%23.jpg)