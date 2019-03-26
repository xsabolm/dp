using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    class SerialPortCommunication
    {

        public List<String> GetNameAllSerialPorts()
        {
            List<String> allNameSerialPorts = new List<String>();
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                allNameSerialPorts.Add(portName);
            }
            return allNameSerialPorts;
        }


    }
}
