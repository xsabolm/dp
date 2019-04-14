using System;
using System.Collections.Generic;

namespace DP_WpfApp
{
    public class Run : Subject
    {
        int Id;
        int Id_discipiline;
        int runNumber;
        Boolean wasSelected = false;
        DateTime startTime;
        DateTime finishTime;
        String comment;
        List<Msg> listMsg;

        public Run()
        {
            StartTime = DateTime.Now;
            Comment = "No Comment";
            ListMsg = new List<Msg>();
        }

        public Run(int idDiscipline)
        {
            ID_discipiline = idDiscipline;
            StartTime = DateTime.Now;
            Comment = "No Comment";
            ListMsg = new List<Msg>();
        }

        public Run(int id, int id_discipilina, DateTime startTime, DateTime finishTime, int runNumber, String comment, List<Msg> listMsg)
        {
            ID = id;
            ID_discipiline = id_discipilina;
            Comment = "No Comment";
            StartTime = startTime;
            FinishTime = finishTime;
            ListMsg = listMsg;
            RunNumber = runNumber;
        }

        public int ID_discipiline { get => Id_discipiline; set => Id_discipiline = value; }
        public int ID { get => Id; set => Id = value; }
        public List<Msg> ListMsg { get => listMsg; set => listMsg = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime FinishTime { get => finishTime; set => finishTime = value; }
        public string Comment { get => comment; set => comment = value; }
        public int RunNumber { get => runNumber; set => runNumber = value; }
        public bool WasSelected { get => wasSelected; set => wasSelected = value; }
    }
}
