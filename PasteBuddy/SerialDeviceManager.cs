using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace PasteBuddy
{
    class SerialDeviceManager
    {
        SerialPort port;

        public SerialDeviceManager()
        {

        }

        ~SerialDeviceManager()
        {
            port.Close();
        }

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
                    port.ReadTimeout = 5000;
                    port.WriteTimeout = 5000;
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
                    port.DiscardOutBuffer();
                    port.DiscardInBuffer();
                    port.WriteLine(str + Environment.NewLine);
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
            Thread.Sleep(200);
            string reply = serialRead();
            return reply;

        }

        public string readButtonRelease(int button)
        {
            // send command so that device will return strings associated with buttons
            string command = "BUTTON:R? " + button.ToString();
            serialWrite(command);
            Thread.Sleep(200);
            string reply = serialRead();
            return reply;
        }

        public void writeButtonPress(int button, string str)
        {
            // send command so that device will return strings associated with buttons
            string command = "BUTTON:SET:P " + button.ToString() + " " + str;
            Thread.Sleep(200);
            serialWrite(command);
        }

        public void writeButtonRelease(int button, string str)
        {
            // send command so that device will return strings associated with buttons
            string command = "BUTTON:SET:R " + button.ToString() + " " + str;
            Thread.Sleep(200);
            serialWrite(command);
        }
    }
}
