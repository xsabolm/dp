using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Okruh : Subject
    {
        int Id;
        int Id_discipilina;
        int casOkruhu;
        List<Sprava> listSprav;

        public Okruh(int id, int id_discipilina, int casOkruhu, List<Sprava> listSprav)
        {
            ID = id;
            ID_discipilina = id_discipilina;
            CasOkruhu = casOkruhu;
            this.listSprav = listSprav;
        }

        public int CasOkruhu { get => casOkruhu; set => casOkruhu = value; }
        public int ID_discipilina { get => Id_discipilina; set => Id_discipilina = value; }
        public int ID { get => Id; set => Id = value; }
    }
}
