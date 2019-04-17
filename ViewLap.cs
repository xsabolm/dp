using lapVisualization;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace DP_WpfApp
{
    public class Point
    {
        double x;
        double y;
        double course;
        int msgNumber;
        public Point(double x, double y) { X = x; Y = y; }
        public Point(double x, double y, int msgNumber) { X = x; Y = y; MsgNumber = msgNumber; }
        public Point(double x, double y, int msgNumber, double course) { X = x; Y = y; MsgNumber = msgNumber; Course = course; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public int MsgNumber { get => msgNumber; set => msgNumber = value; }
        public double Course { get => course; set => course = value; }
    }

    public class ViewLap : INotifyPropertyChanged
    {

        private Point normalizationPoint;
        private Point canvasCenter = new Point(350, 350);
        private double resizeX = 0;
        private double resizeY = 0;

        private double lowestX = 0;
        private double highestX = 0;
        private double lowestY = 0;
        private double highestY = 0;

        private double diameterPoint = 20;
        private double scalePoint = 1;
        private double positionRadius = 5;
        private double vectorRadius = 10;
        private Point detectedStartRunPoint = null;

        public ObservableCollection<UIElement> ObjectCollection { get; set; } = new ObservableCollection<UIElement>();
        public Point NormalizationPoint { get => normalizationPoint; set => normalizationPoint = value; }
        public Point CanvasCenter { get => canvasCenter; set => canvasCenter = value; }

        public double CanvasHeight { get; set; }
        public double CanvasWidth { get; set; }
        public double ResizeX { get => resizeX; set => resizeX = value; }
        public double ResizeY { get => resizeY; set => resizeY = value; }
        public double LowestX { get => lowestX; set => lowestX = value; }
        public double HighestX { get => highestX; set => highestX = value; }
        public double LowestY { get => lowestY; set => lowestY = value; }
        public double HighestY { get => highestY; set => highestY = value; }
        public double ScalePoint { get => this.scalePoint; set => this.scalePoint = value; }
        public double DiameterPoint { get => diameterPoint; set => diameterPoint = value; }
        public double PositionRadius { get => positionRadius; set => positionRadius = value; }
        public double VectorRadius { get => vectorRadius; set => vectorRadius = value; }
        public Point DetectedStartRunPoint { get => detectedStartRunPoint; set => detectedStartRunPoint = value; }

        public List<Point> renderedPointList = new List<Point>();

        internal void addNewGpsMsg(GPSData gPSData, int msgNumber)
        {
            if (ObjectCollection.Count == 0)
            {
                NormalizationPoint = new Point(gPSData.latitude, gPSData.longitude);
                HighestX = CanvasCenter.X;
                LowestX = canvasCenter.X;
                HighestY = canvasCenter.Y;
                LowestY = CanvasCenter.Y;

                Point p = new Point(gPSData.latitude - NormalizationPoint.X, gPSData.longitude - NormalizationPoint.Y, msgNumber, gPSData.course);
                checkNewLap(p);
                drawPoint(p);
                renderedPointList.Add(p);
            }
            else
            {
                Point p = new Point(gPSData.latitude - NormalizationPoint.X, gPSData.longitude - NormalizationPoint.Y, msgNumber, gPSData.course);
                checkNewLap(p);
                renderedPointList.Add(p);
                drawLine(p, renderedPointList[renderedPointList.Count - 2]);
                drawPoint(p);

            }
        }

        private void checkNewLap(Point newPoint)
        {
            if (DetectedStartRunPoint == null)
            {
                if (renderedPointList.Count > 5) //podmienka ze monopost ide 
                {
                    foreach (Point oldPoint in renderedPointList) //mozno neprechadzat cele pole ale iba x sprav na zaciatky
                    {
                        if (isInPositionRadius(oldPoint, newPoint))
                        {
                            if (isInDirectionVectorRadius(oldPoint, newPoint))
                            {
                                Console.WriteLine("NEW RUN");
                                DetectedStartRunPoint = newPoint;  // novy alebo stary
                            }
                        }
                    }
                }
            }
            else
            {
                if (DetectedStartRunPoint.MsgNumber + 10 < newPoint.MsgNumber) //nie je to hned dalsia sprava v radiuse - malo by to byt nastavidelne podla prejdenej vzdialenosti
                {
                    if (isInPositionRadius(DetectedStartRunPoint, newPoint))
                    {
                        if (isInDirectionVectorRadius(DetectedStartRunPoint, newPoint))
                        {
                            Console.WriteLine("NEW RUN");
                            DetectedStartRunPoint = newPoint;  // novy alebo stary
                        }
                    }
                }
            }
        }

        private bool isInDirectionVectorRadius(Point oldPoint, Point newPoint) { return ((newPoint.Course > (oldPoint.Course - VectorRadius)) && (newPoint.Course < (oldPoint.Course + VectorRadius))); }

        private bool isInPositionRadius(Point oldPoint, Point newPoint) { return ((newPoint.X > (oldPoint.X - PositionRadius)) && (newPoint.X < (oldPoint.X + PositionRadius)) && (newPoint.Y > (oldPoint.Y - PositionRadius)) && (newPoint.Y < (oldPoint.Y + PositionRadius))); }


        internal void sizeOfCanvasWasChanged(double actualWidth, double actualHeight)
        {
            CanvasHeight = actualHeight;
            CanvasWidth = actualWidth;
            clearCanvas();
            drawFromList();
        }

        public void drawFromList()
        {
            clearCanvas();
            Point pointBefore = null;
            renderedPointList.ForEach(point =>
            {
                if (pointBefore == null)
                {
                    drawPoint(point);
                }
                else
                {
                    drawLine(point, pointBefore);
                    drawPoint(point);
                }
                pointBefore = point;
            });
        }



        private void checkResizePossibility(Point point)
        {
            Boolean needDraw = false;
            //X vacsie alebo rovne ako height
            if ((CanvasCenter.X + point.X * ScalePoint + diameterPoint + ResizeX) >= CanvasWidth)
            {
                if ((LowestX + (resizeX - 2)) >= 0)
                {
                    ResizeX = ResizeX - 2;
                    HighestX = CanvasCenter.X + point.X * ScalePoint + diameterPoint + ResizeX;
                }
                else
                {
                    changeScalePoint();
                }
                needDraw = true;
            }
            //X je mensie alebo rovne ako 0
            else if ((CanvasCenter.X + point.X * ScalePoint + ResizeX) <= 0)
            {
                if ((HighestX + (resizeX + 2)) <= CanvasWidth)
                {
                    ResizeX = ResizeX + 2;
                    LowestX = CanvasCenter.X + point.X * ScalePoint + ResizeX;
                }
                else
                {
                    changeScalePoint();
                }
                needDraw = true;
            }
            //Y vacsie alebo rovne ako height
            else if ((CanvasCenter.Y + point.Y * ScalePoint + diameterPoint + ResizeY) >= CanvasHeight)
            {
                if ((LowestY + (resizeY - 2)) >= 0)
                {
                    resizeY = resizeY - 2;
                    HighestY = CanvasCenter.Y + point.Y * ScalePoint + diameterPoint + ResizeY;
                }
                else
                {
                    changeScalePoint();
                }
                needDraw = true;
            }
            //Y je mensie alebo rovne ako 0 
            else if ((CanvasCenter.Y + point.Y * ScalePoint + ResizeY) <= 0)
            {
                if ((HighestY + (resizeY + 2)) <= CanvasHeight)
                {
                    resizeY = resizeY + 2;
                    LowestY = CanvasCenter.Y + point.Y * ScalePoint + ResizeY;
                }
                else
                {
                    changeScalePoint();
                }
                needDraw = true;
            }
            if (needDraw) { drawFromList(); }
        }

        private void changeScalePoint()
        {
            ScalePoint = (ScalePoint * 0.75);
            DiameterPoint = DiameterPoint * 0.9;
            HighestX = CanvasCenter.X + (HighestX - CanvasCenter.X) * ScalePoint;
            LowestX = CanvasCenter.X - (CanvasCenter.X - LowestX) * ScalePoint;
            HighestY = CanvasCenter.Y + (HighestY - CanvasCenter.Y) * ScalePoint;
            LowestY = CanvasCenter.Y - (CanvasCenter.Y - LowestY) * ScalePoint;
        }

        private void drawPoint(Point point)
        {
            checkResizePossibility(point);

            Ellipse ellipse = new Ellipse();
            ellipse.Height = diameterPoint;
            ellipse.Width = diameterPoint;
            ellipse.StrokeThickness = 1;
            ellipse.Fill = System.Windows.Media.Brushes.Green;
            ellipse.Stroke = System.Windows.Media.Brushes.Black;

            Canvas.SetLeft(ellipse, CanvasCenter.X + (point.X * ScalePoint + ResizeX));
            Canvas.SetTop(ellipse, CanvasCenter.Y + (point.Y * ScalePoint + ResizeY));

            ObjectCollection.Add(ellipse);
        }

        private void drawLine(Point point1, Point point2)
        {
            System.Windows.Shapes.Line l = new System.Windows.Shapes.Line();
            l.X1 = CanvasCenter.X + ((point1.X * ScalePoint + diameterPoint / 2) + ResizeX);
            l.X2 = CanvasCenter.X + ((point2.X * ScalePoint + diameterPoint / 2) + ResizeX);
            l.Y1 = CanvasCenter.Y + ((point1.Y * ScalePoint + diameterPoint / 2) + ResizeY);
            l.Y2 = CanvasCenter.Y + ((point2.Y * ScalePoint + diameterPoint / 2) + ResizeY);
            l.Stroke = System.Windows.Media.Brushes.Gray;
            l.StrokeThickness = 2;

            ObjectCollection.Add(l);
        }

        internal void clearView()
        {
            ObjectCollection.Clear();
        }

        private void clearCanvas()
        {
            ObjectCollection.Clear();
            System.Windows.Shapes.Rectangle r = new System.Windows.Shapes.Rectangle();
            r.Fill = System.Windows.Media.Brushes.LightGoldenrodYellow;
            r.Width = CanvasWidth;
            r.Height = CanvasHeight;
            Canvas.SetLeft(r, 0);
            Canvas.SetTop(r, 0);
            ObjectCollection.Add(r);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}