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
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxIsSelected(combobox_discipliny))
            {
                log.Info("Selected value: " + AppController.get.ViewDisciplina.CurrentSelection.ID);
            }
        }

        private bool ComboboxIsSelected(ComboBox comboBox)
        {
            return comboBox.SelectedIndex > -1;
        }
    }
}
