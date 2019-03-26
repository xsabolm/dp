using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Sprava
    {
        int id;
        int idDisciplina;
        int idOkruh;
        DateTime casPrijatia; //datatime type

        public Sprava(int id, int idOkruh, DateTime casPrijatia)
        {
            ID = id;
            ID_okruh = idOkruh;
            CasPrijatia = casPrijatia;
        }

        public int ID { get => id; set => id = value; }
        public int IDdisciplina { get => idDisciplina; set => idDisciplina = value; }
        public int ID_okruh { get => idOkruh; set => idOkruh = value; }
        public DateTime CasPrijatia { get => casPrijatia; set => casPrijatia = value; }


    }
}
