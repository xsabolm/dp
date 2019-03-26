using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Meranie : Subject
    {
        int Id;
        DateTime casMerania; //datatime type
        Boolean typ; //true = live, false = histroric
        String detaily;
        String lokacia;
        public List<Disciplina> listDisciplin = new List<Disciplina>();

        public Meranie(int Id, DateTime casMerania, Boolean typ, String detaily, String lokacia)
        {
            //for list and combobox
            this.Id = Id;
            this.casMerania = casMerania;
            this.typ = typ;
            this.detaily = detaily;
            this.lokacia = lokacia;
        }

        public Meranie(int Id, DateTime casMerania, Boolean typ, String detaily, String lokacia, List<Disciplina> listDisciplin)
        {
            this.Id = Id;
            this.casMerania = casMerania;
            this.typ = typ;
            this.detaily = detaily;
            this.lokacia = lokacia;
            this.listDisciplin = listDisciplin;
        }

        public int ID { get => Id; set => Id = value; }
        public DateTime CasMerania { get => casMerania; set => casMerania = value; }
        public bool Typ { get => typ; set => typ = value; }
        public string Detaily { get => detaily; set => detaily = value; }
        public string Lokacia { get => lokacia; set => lokacia = value; }

    }
}
