using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class SelectedMsges : Subject
    {
        Queue<Msg> queueMsges = new Queue<Msg>();
        Msg actulMsg;
        Boolean isSelectedMsg = false;

        public SelectedMsges()
        {

        }

        public Msg ActulMsg { get => actulMsg; set => actulMsg = value; }
        public Queue<Msg> QueueMsges { get => queueMsges; set => queueMsges = value; }
        public bool IsSelectedMsg { get => isSelectedMsg; set => isSelectedMsg = value; }

        public void setList(List<Msg> list)
        {
            list.ForEach(msg => QueueMsges.Enqueue(msg));
            IsSelectedMsg = true;
        }
    }
}
