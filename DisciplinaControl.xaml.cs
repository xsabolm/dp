using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DP_WpfApp
{
    /// <summary>
    /// Interaction logic for DisciplinaControl.xaml
    /// </summary>
    public partial class DisciplinaControl : UserControl
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DisciplinaControl()
        {
            InitializeComponent();
            DataContext = AppController.get.ViewDisciplina;
            btn_endDisciplin.IsEnabled = false;
            btn_save.IsEnabled = false;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxIsSelected(combobox_discipliny))
            {
                AppController.get.setObserverForRun(AppController.get.ViewDisciplina.CurrentSelectionDiscipline.ID);
            }
        }

        private bool ComboboxIsSelected(ComboBox comboBox)
        {
            return comboBox.SelectedIndex > -1;
        }

        private void combobox_okruh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxIsSelected(combobox_okruh))
            {
                if (AppController.get.IsLiveData)
                {
                    AppController.get.setSelectedRunFromCount(AppController.get.ViewDisciplina.CurrentSelectionRun.ID);
                }
                else
                {
                    AppController.get.setSelectedRunFromDataBase(AppController.get.ViewDisciplina.CurrentSelectionRun.ID);
                }
            }
        }

        private void btn_endDisciplin_Click(object sender, RoutedEventArgs e)
        {
            //AppController.get.Model.closeDiscipline();
            AppController.get.closeDiscipline();
            btn_startDisciplin.IsEnabled = true;
            btn_endDisciplin.IsEnabled = false;
            btn_save.IsEnabled = true;
        }

        private void btn_startDisciplin_Click(object sender, RoutedEventArgs e)
        {
            // if (AppController.get.Model.createNewDiscipline())
            if (AppController.get.newDiscipline())
            {
                btn_startDisciplin.IsEnabled = false;
                btn_endDisciplin.IsEnabled = true;
                btn_save.IsEnabled = false;
            }

        }

        private void btn_saveDatabase_Click(object sender, RoutedEventArgs e)
        {
            AppController.get.saveToDataBase();
        }
    }
}
