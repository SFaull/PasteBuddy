using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PasteBuddy
{
    class SerialDeviceManager
    {
        SerialPort port;

        public void Connect(string portName)
        {
            if (!isConnected())
            {
                port = new SerialPort(portName);
                if (!port.IsOpen)
                {
                    port.BaudRate = 115200;
                    port.DataBits = 8;
                    port.StopBits = StopBits.One;
                    port.Parity = Parity.None;
                    port.Handshake = Handshake.None;
                    port.ReadTimeout = 1000;
                    port.WriteTimeout = 1000;
                    port.Open();
                }
            }
        }

        public string[] getComPorts()
        {
            return SerialPort.GetPortNames();
        }

        public bool isConnected()
        {
            if (port != null && port.IsOpen)
                return true;
            return false;
        }

        private string serialRead()
        {
            String str = "";

            if (isConnected())
            {
                try
                {
                    str = port.ReadLine();
                }
                catch   // timeout
                {
                    str = "Error";
                }
            }

            return str;
        }

        private void serialWrite(string str)
        {
            if (isConnected())
            {
                try
                {
                    port.WriteLine(str);
                }
                catch   // timeout
                {
                    // write error/timeout
                }
            }
        }

        public string readButtonPress(int button)
        {
            // send command so that device will return strings associated with buttons
            string command = "BUTTON:P? " + button.ToString();
            serialWrite(command);
            return serialRead();

        }

        public string readButtonRelease(int button)
        {
            // send command so that device will return strings associated with buttons
            string command = "BUTTON:R? " + button.ToString();
            serialWrite(command);
            return serialRead();
        }

        public void writeButtonPress(int button, string str)
        {
            // send command so that device will return strings associated with buttons
            string command = "BUTTON:P:" + button.ToString() + " " + str;
            serialWrite(command);
        }

        public void writeButtonRelease(int button, string str)
        {
            // send command so that device will return strings associated with buttons
            string command = "BUTTON:R:" + button.ToString() + " " + str;
            serialWrite(command);
        }
    }
}
