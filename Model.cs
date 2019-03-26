using connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Model
    {
        Meranie meranie;

        internal Meranie Meranie { get => meranie; set => meranie = value; }

        List<Meranie> allMerania;

        public void loadMerniaDetails()
        {
            allMerania = LoadModelFromDataBase.loadMernia();
        }

        public void loadData(int idMeranie)
        {
            Meranie = LoadModelFromDataBase.getAllMeranieObjectFromDataBase(idMeranie);
        }

        public void loadData()
        {
            //live data
        }
    }
}
