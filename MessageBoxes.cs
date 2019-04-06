using connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_WpfApp
{
    class MessageBoxes
    {
        public static void loadMeranieFromDataBase(int ID, String label)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Nacitat historicke udaje merania: " + label, "Nacitat meranie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AppController.get.loadModel(ID);
            }
            else if (dialogResult == DialogResult.No)
            {
                //not sure what to do here
            }
        }

        public static void saveExistingModel(Mensuration mensuration)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Ulozit meranie do databazy", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataBaseServices.insertModel(mensuration);
            }
            else if (dialogResult == DialogResult.No)
            {
                //not sure what to do here
            }
        }

        internal static void didNotSetConnection()
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Settings -> Live data", "FIRST YOU NEED SET CONENCTION", MessageBoxButtons.OK);
        }
    }
}
