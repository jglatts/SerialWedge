
# Simple Serial Data Keyboard Wedge

Sends serial port data to any application (e.g., Excel, Notepad, ERP systems).  
Can collect data from **Serial, RS232, and RS232-via-USB** industrial equipment.  
Supports **real-time data viewing** and **custom data handling**.  

## Features  
✅ Sends serial data as **keyboard input**  
✅ Works with **RS232, USB-to-Serial devices, and industrial equipment**  
✅ **Real-time data viewing** for monitoring incoming data  
✅ **Customizable serial data processing** via `SerialReaderBase`  
✅ Supports **multiple baud rates and handshake methods**  


---


## Compatible Devices  

| Device Type       | Examples |
|------------------|-----------------------------------|
| **Barcode Readers**  | Handheld scanners, POS systems  |
| **Weighing Scales**  | Industrial balances, lab scales |
| **Meters**          | Voltage meters, pressure gauges  |
| **Calipers**         | Digital calipers, micrometers   |
| **Sensors**          | Temperature, force, pH sensors  |
| **Custom Devices**   | Any RS232-based industrial tool |

Builds upon https://github.com/pormiston/SerialWedge


---


## System Screenshot
![system_gui](https://raw.githubusercontent.com/jglatts/SerialWedge/refs/heads/master/images/gui2.png)


---


## How To Run  

### From GitHub Releases 
1. **Go to the Releases page**: [SerialWedge Releases](https://github.com/jglatts/SerialWedge/releases)  
2. **Download** the latest **Assets** from the Assests section on the Releases page 
3. **Run** the application (no installation required)  

### From Source  
1. **Clone the repo:**  
   ```sh
   git clone https://github.com/jglatts/SerialWedge.git
   ```
2. **Open** the SLN file in VisualStudio


---


## Creating a Custom Serial Reader for the Keyboard Wedge  

To implement a **custom serial reader**, follow these steps:  

### 1. Create a New Class that Inherits `SerialReaderBase`  
Your custom serial reader must be a **subclass of `SerialReaderBase`**.  
This ensures it integrates smoothly with the wedge system.  

**Important:** The `worker()` method is essential—it runs in a loop and continuously reads, processes, and sends serial data as keyboard input. 
Without properly implementing this method, your device will not function within the wedge system.

#### Example: Creating `MyDeviceSerialReader`  
```csharp
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Wedgies
{
    class MyDeviceSerialReader : SerialReaderBase
    {

        /*
            Constructor for the custom serial reader.
            Calls the base class constructor to initialize the serial port and callback.
        */
        public MyDeviceSerialReader(SerialPort port, UpdateCallback callback)
            : base(port, callback)
        {
        }

        /*
            Serial Port settings (handshake and baud) for your implementation. 
            This will load the GUI with your settings on start-up. 
        */
        public override PortSettings getPortSettings()
        {
            return new PortSettings("XOnXOff", 2400);
        }

        /*
            Initialize serial port settings specific to your device.
        */
        public override void initPort()
        {
            // example usage:
            port.Parity = Parity.Even;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.DtrEnable = true;
            port.RtsEnable = false;
        }

        /*
            Core method for reading and processing serial data.

            This method is called repeatedly in a loop while the reader is running.
            Use this method to customize how data is interpreted and processed. 
        */
        public override bool worker()
        {
            bool ret = true;
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
                // No data available
                ret = false;
            }
            return ret;
        }
    }
}
```


### 2. Instantiate and Use Your Custom Reader  
In `frmwedge.cs`, you  instantiate your reader in the `setSerialReader()` method
```csharp
public void setSerialReader()
{
    serialReader = new MyDeviceSerialReader(port, updateLiveInput);
}
```

---

## Why This Is Effective  
![funny_img](https://raw.githubusercontent.com/jglatts/SerialWedge/refs/heads/master/images/funny-c%23.jpg)