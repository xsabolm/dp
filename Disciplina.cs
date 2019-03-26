using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Disciplina : Subject
    {
        int Id;
        int Id_meranie;
        String typDiscipiliny;
        List<Okruh> listOkruhov;

        public Disciplina(int id, int id_meranie, String typDiscipiliny, List<Okruh> listOkruhov)
        {
            ID = id;
            ID_meranie = id_meranie;
            TypDiscipiliny = typDiscipiliny;
            this.listOkruhov = listOkruhov;
        }

        public int ID { get => Id; set => Id = value; }
        public int ID_meranie { get => Id_meranie; set => Id_meranie = value; }
        public string TypDiscipiliny { get => typDiscipiliny; set => typDiscipiliny = value; }

    }
}
