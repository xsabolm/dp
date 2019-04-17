using DP_WpfApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace lapVisualization
{
    /// <summary>
    /// Interaction logic for LapControl.xaml
    /// </summary>
    /// 

    public partial class LapControl : UserControl
    {
        ObservableCollection<UIElement> ObjectCollection { get; set; } = new ObservableCollection<UIElement>();

        public LapControl()
        {
            InitializeComponent();
            LapControlItem.ItemsSource = AppController.get.ViewMain.ViewLap.ObjectCollection;
            AppController.get.ViewMain.ViewLap.CanvasHeight = ActualHeight;
            AppController.get.ViewMain.ViewLap.CanvasWidth = ActualWidth;
            DataContext = this;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var canvas = (Canvas)sender;
            System.Windows.Point point = e.GetPosition(canvas);
            
            Console.WriteLine("Selected point x: " + point.X + ", y: " + point.Y);
        }

        private void canvas_my_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AppController.get.ViewMain.ViewLap.sizeOfCanvasWasChanged(this.ActualWidth, this.ActualHeight);
        }
    }
}