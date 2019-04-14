using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lapVisualization
{
    /// <summary>
    /// Interaction logic for LapControl.xaml
    /// </summary>
    /// 
    public class Line
    {
        public Point From { get; set; }

        public Point To { get; set; }
    }

    public partial class LapControl : UserControl, INotifyPropertyChanged
    {
        public ObservableCollection<Line> Lines { get; private set; }

        public LapControl()
        {
            Lines = new ObservableCollection<Line>
        {
            new Line { From = new Point(100, 20), To = new Point(180, 180) },
            new Line { From = new Point(180, 180), To = new Point(20, 180) },
            new Line { From = new Point(20, 180), To = new Point(100, 20) },
            new Line { From = new Point(20, 50), To = new Point(180, 150) }
        };

            InitializeComponent();
            DataContext = this;
        }
    
    

    public event PropertyChangedEventHandler PropertyChanged;

    private Polygon p;
    private Polyline segment = new Polyline();

    private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (p == null)
        {
            var canvas = (Canvas)sender;
            var point = e.GetPosition(canvas);

            // create new polyline
            p = new Polygon();
            p.Stroke = Brushes.Black;
            p.Points.Add(point);
            //canvas.Children.Add(p);

            // initialize current polyline segment
            segment.Stroke = Brushes.Red;
            segment.Points.Add(point);
            segment.Points.Add(point);
            canvas.Children.Add(segment);
        }
    }

    private void Canvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (p != null)
        {
            // update current polyline segment
            var canvas = (Canvas)sender;
            segment.Points[1] = e.GetPosition(canvas);
            segment.Stroke = Brushes.Blue;
        }
    }

    private void Canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        p = null;
        segment.Points.Clear();
        //canvas.Children.Remove(segment);
    }
    private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (p != null)
        {
            var canvas = (Canvas)sender;
            segment.Points[1] = e.GetPosition(canvas);

            p.Points.Add(segment.Points[1]);
            segment.Points[0] = segment.Points[1];
        }
    }
}
}