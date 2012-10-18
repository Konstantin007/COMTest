using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace COMTest
{
    class Modul7018
    {
        private SerialPort port;
 
        public Modul7018(String portName)
        {
            this.openPort(portName);
        }

        private void openPort(String portName)
        {
            port = new SerialPort();
            port.PortName = portName;
            port.BaudRate = 9600;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;
            port.Handshake = Handshake.None;
            port.ReceivedBytesThreshold = 8;
            port.WriteBufferSize = 20;
            port.ReadBufferSize = 20;
            port.ReadTimeout = -1;
            port.WriteTimeout = -1;
            port.DtrEnable = false;
            port.Open();
            port.RtsEnable = true;
            System.Threading.Thread.Sleep(100);
        }

        public void writeToPort(String command)
        {
            port.WriteLine(command + (char)0x0D);
        }

        public String readFromPort()
        {
            System.Threading.Thread.Sleep(100);
            byte[] data = new byte[port.BytesToRead];
            port.Read(data, 0, data.Length);
            port.DiscardInBuffer();
            String str = "";
            for (int i = 0; i < data.Length; i++)
            {
                str += ((char)data[i]).ToString();
            }

            str = "\t" + str;

            return str;
        }

        public void closePort()
        {
            if (port.IsOpen)
            {
                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                port.Close();
            }
        }
    }
}
