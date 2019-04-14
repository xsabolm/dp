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

        public LiveConnection(String name, int boudRate)
        {
            log.Info(" Port name:" + name);

            port = new SerialPort(name, boudRate, Parity.None, 8, StopBits.One);
            //port.ReceivedBytesThreshold = 1;
            port.DtrEnable = true;
            port.RtsEnable = true;
        }


        [STAThread]
        public static void startPort()
        {
            if (AppController.get.IsLiveData) { port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived); }
            port.Open();
            // Enter an application loop to keep this thread alive 
            Console.ReadLine();
        }

        private static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try { AppController.get.ProcessingLiveData.processing(port.ReadLine()); }
            catch (Exception exception) { log.Error("Error in processing data: " + exception.ToString()); }
        }

        public void closePort() { port.Close(); }
    }
}
