using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public abstract class Subject
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Boolean wasSaved = false;
        private List<Observer> observers = new List<Observer>();

        public bool WasSaved { get => wasSaved; set => wasSaved = value; }

        public void Attach(Observer observer)
        {
            if(observers.Count == 0)
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
                log.Info("Observer was notified");
            }
        }
    }
}
