using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Mensuration : Subject
    {
        int Id;
        DateTime startTime; //datatime type
        String comment;
        String locality;
        private List<Discipline> listDiscipline = new List<Discipline>();


        public int ID { get => Id; set => Id = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public string Comment { get => comment; set => comment = value; }
        public string Locality { get => locality; set => locality = value; }
        public List<Discipline> ListDiscipline { get => listDiscipline; set => listDiscipline = value; }

        public Mensuration()
        {
            StartTime = DateTime.Now;
            Comment = "No Comment";
            Locality = "No Locality";
        }

        public Mensuration(int Id, DateTime startTime,  String comment, String locality)
        {
            ID = Id;
            StartTime = startTime;
            Comment = comment;
            Locality = locality;
        }


        public Mensuration(int Id, DateTime startTime, String comment, String locality, List<Discipline> listDiscipline)
        {
            ID = Id;
            StartTime = startTime;
            Comment = comment;
            Locality = locality;
            ListDiscipline = listDiscipline;
        }


    }
}
