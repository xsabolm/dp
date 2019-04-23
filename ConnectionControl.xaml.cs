using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlServerCe;
using static connection.DataBaseServices;
using System.Data;
using System.Collections;
using connection;
using DP_WpfApp;

namespace connection
{
    /// <summary>
    /// Interaction logic for ConnectionControl.xaml
    /// </summary>
    /// 
    public partial class ConnectionControl : System.Windows.Controls.UserControl
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ConnectionControl()
        {
            InitializeComponent();
            comboBoxMensuration.DataContext = AppController.get.ViewMeranie;
            comboBoxDiscipline.DataContext = AppController.get.ViewMeranie;
            textDisciplineComment.DataContext = AppController.get.ViewMeranie;
            textDisciplineName.DataContext = AppController.get.ViewMeranie;
            textMensurationComment.DataContext = AppController.get.ViewMeranie;
            textMensurationLocality.DataContext = AppController.get.ViewMeranie;
            textViewDiscipline.DataContext = AppController.get.ViewMeranie;
            textView.DataContext = AppController.get.ViewMeranie;


            comboBoxPorts.DataContext = AppController.get.ViewLiveConnection;
            btnLiveConnectionClose.DataContext = AppController.get.ViewLiveConnection;
            btnLiveConnectionOpen.DataContext = AppController.get.ViewLiveConnection;

        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            txtBoxOpenFile.Text = openFileDialog.FileName;
            log.Info("Choosen file is " + openFileDialog.FileName);
        }

        private void btnACKOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(txtBoxOpenFile.Text))
            {
                string contents = File.ReadAllText(txtBoxOpenFile.Text);
                log.Info("Click on ok button - ACK");
            }
            else
            {
                log.Info("Empty file textBox");
            }
        }

        private void btnConnectToDataBase_Click(object sender, RoutedEventArgs e)
        {
            if (ComboboxIsSelected(comboBoxMensuration))
            {
                MessageBoxes.loadMeranieFromDataBase(AppController.get.ViewMeranie.CurrentSelectionFromCombobox.ID, comboBoxMensuration.SelectedValue.ToString());
            }
        }

        private void comboBoxMensuration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private bool ComboboxIsSelected(System.Windows.Controls.ComboBox comboBox)
        {
            return comboBox.SelectedIndex > -1;
        }

        private void btnLiveConnection_Open(object sender, RoutedEventArgs e)
        {
            if (ComboboxIsSelected(comboBoxPorts))
            {
                //default baoudRate
                int boudRate = 115200;
                if (ComboboxIsSelected(comboboxBaudRate))
                {
                    boudRate = Convert.ToInt32(comboboxBaudRate.Text);
                }

                AppController.get.loadModel(AppController.get.ViewLiveConnection.CurrentSelectionPort.Label, boudRate);
            }
        }

        private void btnLiveConnection_Close(object sender, RoutedEventArgs e)
        {
            AppController.get.closeLiveConnection();
        }

        private void refreshPortList(object sender, RoutedEventArgs e)
        {
            AppController.get.ViewLiveConnection.addToCombobox();
        }

        private void btnRefreshMenusrations_Click(object sender, RoutedEventArgs e)
        {
            AppController.get.Model.loadMensurations();
            AppController.get.ViewMeranie.refreshMensuration();

        }


        private void comboBoxDiscipline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChooseDiscipline_Click(object sender, RoutedEventArgs e)
        {
            if (ComboboxIsSelected(comboBoxDiscipline))
            {
                AppController.get.ViewMeranie.setDisciplinePartOfView();
            }
        }

        private void btnUpdateDisciplineComment_Click(object sender, RoutedEventArgs e)
        {
            DataBaseServices.updateDisciplineComment(AppController.get.ViewMeranie.CurrentSelectionFromDisciplineCombobox.ID, textDisciplineComment.Text.ToString());
        }

        private void btnUpdateDisciplineName_Click(object sender, RoutedEventArgs e)
        {
            DataBaseServices.updateDisciplineName(AppController.get.ViewMeranie.CurrentSelectionFromDisciplineCombobox.ID, textDisciplineName.Text.ToString());
        }

        private void btnUpdateMensurationLocality_Click(object sender, RoutedEventArgs e)
        {
            DataBaseServices.updateMensurationLocality(AppController.get.ViewMeranie.CurrentSelectionFromCombobox.ID, textMensurationLocality.Text.ToString());

        }

        private void btnUpdateMensurationComment_Click(object sender, RoutedEventArgs e)
        {
            DataBaseServices.updateMensurationComment(AppController.get.ViewMeranie.CurrentSelectionFromCombobox.ID, textMensurationComment.Text.ToString());

        }
    }
}
