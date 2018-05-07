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

        public bool Connect(string portName)
        {
            bool success = false;
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
                    port.DtrEnable = true;
                    port.ReadTimeout = 5000;
                    port.WriteTimeout = 5000;
                    port.Open();
                    Thread.Sleep(500);  // wait a little bit for device to become responsive

                    success = isPasteBuddy();

                    if (!success)
                    {
                        port.Close();
                    }
                }
            }
            return success;
        }

        public void Disconnect()
        {
            port.Close();
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

        private bool isPasteBuddy()
        {
            serialWrite("*IDN?");
            string result = serialRead();
            return result.Equals("PasteBuddy");
        }

        private string serialRead()
        {
            String str = "";

            if (isConnected())
            {
                try
                {
                    str = port.ReadLine();
                    str = str.TrimEnd('\r', '\n');
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
            str = str + "\r";   // add a CR
            if (isConnected())
            {
                try
                {
                    port.DiscardOutBuffer();
                    port.DiscardInBuffer();
                    port.WriteLine(str);
                }
                catch   // timeout
                {
                    // write error/timeout
                }
            }
        }



        public int buttonCount()
        {
            int button_count = 0;
            string command = "BUTTONS?";
            serialWrite(command);
            string reply = serialRead();
            Int32.TryParse(reply, out button_count);
            return button_count;
        }

        public string readButtonPress(int button)
        {
            // send command so that device will return strings associated with buttons
            string command = "PRESS? " + button.ToString();
            serialWrite(command);
            string reply = serialRead();
            return reply;

        }

        public string readButtonRelease(int button)
        {
            // send command so that device will return strings associated with buttons
            string command = "RELEASE? " + button.ToString();
            serialWrite(command);
            string reply = serialRead();
            return reply;
        }

        public void writeButtonPress(int button, string str)
        {
            str = str.Replace(' ', '|');    // send the string without spaces
            // send command so that device will return strings associated with buttons
            string command = "SET:PRESS " + button.ToString() + " " + str;
            serialWrite(command);
            string result = serialRead();   // this will be "OK" if success, "ERR" if fail
        }

        public void writeButtonRelease(int button, string str)
        {
            str = str.Replace(' ', '|');    // send the string without spaces
            // send command so that device will return strings associated with buttons
            string command = "SET:RELEASE " + button.ToString() + " " + str;
            serialWrite(command);
            string result = serialRead();   // this will be "OK" if success, "ERR" if fail
        }

        public void eraseDevice()
        {
            string command = "EEPROM:ERASE";
            serialWrite(command);
            string result = serialRead();   // this will be "OK" if success, "ERR" if fail
        }
    }
}
