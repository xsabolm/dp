using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Discipline : Subject
    {
        int Id;
        int id_mensuration;
        String comment;
        String name;
        List<Run> listRuns;

        public Discipline(int id, int id_mensuration)
        {
            ID = id;
            ID_mensuration = id_mensuration;
            Comment = "No comment";
            Name = "No name";
            ListRuns = new List<Run>();
        }

        public Discipline(int id, int id_mensuration, String comment, String name, List<Run> listRuns)
        {
            ID = id;
            ID_mensuration = id_mensuration;
            Comment = comment;
            Name = name;
            ListRuns = listRuns;
        }

        public int ID { get => Id; set => Id = value; }
        public int ID_mensuration { get => id_mensuration; set => id_mensuration = value; }
        public string Comment { get => comment; set => comment = value; }
        public string Name { get => name; set => name = value; }
        public List<Run> ListRuns { get => listRuns; set => listRuns = value; }
    }
}
