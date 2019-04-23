namespace DP_WpfApp
{
    internal class ObserverSelectedMsg : Observer
    {
        ViewMain viewMain;
        SelectedDiscipline selectedDiscipline;

        public SelectedDiscipline SelectedDiscipline { get => selectedDiscipline; set => selectedDiscipline = value; }
        public ViewMain ViewMain { get => viewMain; set => viewMain = value; }

        public ObserverSelectedMsg(ViewMain viewMain, SelectedDiscipline selectedDiscipline)
        {
            ViewMain = viewMain;
            SelectedDiscipline = selectedDiscipline;
        }

        public override void Update()
        {
            if (SelectedDiscipline.SelectedMsges.IsSelectedMsg)
            {
                 while (SelectedDiscipline.SelectedMsges.QueueMsges.Count > 0)
                {
                    ViewMain.ViewActualMsg.newMsg(SelectedDiscipline.SelectedMsges.QueueMsges.Dequeue());
                }
            }
            else
            {
                ViewMain.ViewActualMsg.newMsg(SelectedDiscipline.SelectedMsges.ActulMsg);
            }
        }
    }
}