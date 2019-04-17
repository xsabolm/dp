using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using DP_WpfApp;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Events;
using LiveCharts.Geared;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace graphVisualization
{
    /// <summary>
    /// Interaction logic for BasicGraph.xaml
    /// </summary>
    /// 
    public class DateModel
    {
        public System.DateTime DateTime { get; set; }
        public int Value { get; set; }
    }

    public partial class BasicGraph : UserControl, INotifyPropertyChanged
    {
        private static string[] comboboxLabels = { "BBOX_power", "BBOX_status", "GPS_data", "ECU_State", "BBOX_command", "FU_Values_1", "Interconnect", "FU_Values_2", "BMS_Command", "BMS_State", "wheel_RPM", "BMS_Voltages", "BMS_Temps" };
        private static string[] comboboxBBOXPowerLabels = { "power", "current", "voltage" };
        private static string[] comboboxBBOXStatusLabels = { "SHD_IN", "SHD_OUT", "TSMS", "AIR_N", "AIR_P", "PRECH_60V", "IMD_OK", "BMS_OK", "SIGNAL_ERROR", "SHD_RESET", "SHD_EN", "POLARITY", "FANS", "STM_temp" };
        private static string[] comboboxGPSDataLabels = { "latitude",/* "latitude_char",*/ "longitude",/* "longitude_char",*/ "speed", "course", "altitude" };
        private static string[] comboboxECUStateLabels = { "ECU_Status", "FL_AMK_Status", "FR_AMK_Status", "RL_AMK_Status", "RR_AMK_Status", "TempMotor_H", "TempInverter_H", "TempIGBT_H" };
        private static string[] comboboxBBOXCommandLabels = { "FANS", "SHD_EN" };
        private static string[] comboboxFUValues1Labels = { "apps1", "apps2", "brake1", "brake2", "error" };
        private static string[] comboboxInterconnectLabels = { "car_state", "left_w_pump", "right_w_pump", "brake_red", "brake_white", "tsas", "killswitch_R", "killswitch_L", "reserve", "susp_RR", "susp_RL" };
        private static string[] comboboxFUValues2Labels = { "steer", "susp_FL", "susp_FR", "brake_pos", "RTD", "BOTS", "SHDB", "INERTIA_SW", "reserve" };
        private static string[] comboboxBMSCommandLabels = { "BMS_Balanc", "BMS_FullMode", "BMS_OK", "BMS_ONOFF", "BMS_CAN" };
        private static string[] comboboxBMSStateLabels = { "BMS_Mode", "BMS_Faults", "CellVolt_L", "CellVolt_H", "CellTemp_L", "CellTemp_H", "BMS_Ident" };
        private static string[] comboboxWheelRPMLabels = { "front_right", "front_left", "rear_right", "rear_left" };
        private static string[] comboboxBMSVoltagesLabels = { "BMS_VoltIdent", "BMS_Volt1", "BMS_Volt2", "BMS_Volt3", "BMS_Volt4", "BMS_Volt5", "BMS_Volt6", "BMS_Volt7" };
        private static string[] comboboxBMSTempsLabels = { "BMS_TempIdent", "BMS_Temp1", "BMS_Temp2", "BMS_Temp3", "BMS_Temp4", "BMS_Temp5", "BMS_Temp6", "BMS_Temp7" };

        public event PropertyChangedEventHandler PropertyChanged;
        public Func<double, string> Formatter { get; set; }

        public BasicGraph()
        {
            InitializeComponent();
            SeriesCollection = AppController.get.ViewMain.ViewGraph.SeriesCollection;
            combobox_graf_items.ItemsSource = comboboxLabels;
            Formatter = value => new DateTime((long)value).ToString("mm:ss:fff");
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void combobox_graf_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox_graf_items.SelectedIndex > -1)
            {
                if (combobox_graf_items.SelectedValue.Equals("BBOX_power"))
                {
                    combobox_graf_items2.ItemsSource = comboboxBBOXPowerLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("BBOX_status"))
                {
                    combobox_graf_items2.ItemsSource = comboboxBBOXStatusLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("GPS_data"))
                {
                    combobox_graf_items2.ItemsSource = comboboxGPSDataLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("ECU_State"))
                {
                    combobox_graf_items2.ItemsSource = comboboxECUStateLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("BBOX_command"))
                {
                    combobox_graf_items2.ItemsSource = comboboxBBOXCommandLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("FU_Values_1"))
                {
                    combobox_graf_items2.ItemsSource = comboboxFUValues1Labels;
                }
                if (combobox_graf_items.SelectedValue.Equals("Interconnect"))
                {
                    combobox_graf_items2.ItemsSource = comboboxInterconnectLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("FU_Values_2"))
                {
                    combobox_graf_items2.ItemsSource = comboboxFUValues2Labels;
                }
                if (combobox_graf_items.SelectedValue.Equals("BMS_Command"))
                {
                    combobox_graf_items2.ItemsSource = comboboxBMSCommandLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("BMS_State"))
                {
                    combobox_graf_items2.ItemsSource = comboboxBMSStateLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("wheel_RPM"))
                {
                    combobox_graf_items2.ItemsSource = comboboxWheelRPMLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("BMS_Voltages"))
                {
                    combobox_graf_items2.ItemsSource = comboboxBMSVoltagesLabels;
                }
                if (combobox_graf_items.SelectedValue.Equals("BMS_Temps"))
                {
                    combobox_graf_items2.ItemsSource = comboboxBMSTempsLabels;
                }
            }
        }

        private void combobox_graf_items2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox_graf_items2.SelectedIndex > -1)
            {
                AppController.get.ViewMain.addLinesToGraph(combobox_graf_items.SelectedValue.ToString(), combobox_graf_items2.SelectedValue.ToString());
            }
        }

        private void btn_clearGraph_Click(object sender, RoutedEventArgs e)
        {
            AppController.get.ViewMain.ViewGraph.clearLists();
        }
    }
}