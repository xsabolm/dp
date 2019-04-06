using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class LiveConnection
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static SerialPort port;

        public LiveConnection(String name)
        {
            port = new SerialPort(name, 9600, Parity.None, 8, StopBits.One);
            SerialPortProgram();
        }

        [STAThread]
        private static void SerialPortProgram()
        {
            // Attach a method to be called when there
            // is data waiting in the port's buffer 
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            // Begin communications 
            port.Open();
            // Enter an application loop to keep this thread alive 
            Console.ReadLine();
        }

        private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            AppController.get.ProcessingLiveData.processing(port.ReadLine());
        }

        public void closePort()
        {
            port.Close();
        }

    }
}
