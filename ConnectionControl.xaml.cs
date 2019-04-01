﻿using System;
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
using DP_WpfApp;

namespace connection
{
    /// <summary>
    /// Interaction logic for ConnectionControl.xaml
    /// </summary>
    /// 
    public partial class ConnectionControl : System.Windows.Controls.UserControl
    {
        private const bool IsHistoryData = false;
        private const bool IsLiveData = true;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ConnectionControl()
        {
            InitializeComponent();
            comboBoxMeranie.DataContext = AppController.get.ViewMeranie;
            textView.DataContext = AppController.get.ViewMeranie;
            comboBoxPorts.DataContext = AppController.get.ViewLiveConnection;


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
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Nacitat historicke udaje merania: " + comboBoxMeranie.SelectedValue, "Nacitat meranie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Load data from merania
                if (ComboboxIsSelected(comboBoxMeranie))
                {
                    AppController.get.loadModel(AppController.get.ViewMeranie.CurrentSelectionFromCombobox.ID, IsHistoryData);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //not sure what to do here
            }
        }

        private void comboBoxMeranie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private bool ComboboxIsSelected(System.Windows.Controls.ComboBox comboBox)
        {
            return comboBox.SelectedIndex > -1;
        }

        private void btnLiveConnection_Click(object sender, RoutedEventArgs e)
        {
            if (ComboboxIsSelected(comboBoxPorts))
            {
                AppController.get.setLiveConnection(AppController.get.ViewLiveConnection.CurrentSelectionPort.Label);
            }

        }
    }
}
