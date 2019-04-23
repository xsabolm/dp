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
    public class ViewLap : ViewModel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Point canvasCenter = new Point(350, 350);
        private double resizeX = 0;
        private double resizeY = 0;

        private double lowestX = 0;
        private double highestX = 0;
        private double lowestY = 0;
        private double highestY = 0;
        private double scalePoint = 1;

        private double diameterPoint = 20;

        public ObservableCollection<String> comboboxListRuns { get; } = new ObservableCollection<String>();
        public ObservableCollection<UIElement> ObjectCollection { get; set; } = new ObservableCollection<UIElement>();
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
        Point pointBefore = null;
        public List<Point> renderedPointList = new List<Point>();

        public void addPointList(List<Point> pointList)
        {
            renderedPointList.Clear();
            renderedPointList.AddRange(pointList);
            drawFromList();
        }

        public void addPoint(Point point)
        {
            renderedPointList.Add(point);
            drawPoint(point);
        }

        public void drawPoint(Point point)
        {
            if (pointBefore == null)
            {
                drawPoint(point, false);
            }
            else
            {
                drawLine(point, pointBefore);
                drawPoint(point, false);
            }
            pointBefore = point;
        }

        internal void sizeOfCanvasWasChanged(double actualWidth, double actualHeight)
        {
            CanvasHeight = actualHeight;
            CanvasWidth = actualWidth;
            CanvasCenter.X = actualWidth / 2;
            CanvasCenter.Y = actualHeight / 2;
            HighestX = CanvasCenter.X;
            LowestX = canvasCenter.X;
            HighestY = canvasCenter.Y;
            LowestY = CanvasCenter.Y;
            clearCanvas();
            drawFromList();
        }

        public void drawFromList()
        {
            clearCanvas();
            pointBefore = null;
            renderedPointList.ForEach(point =>
            {
                if (pointBefore == null)
                {
                    drawPoint(point, false);
                }
                else
                {
                    drawLine(point, pointBefore);
                    drawPoint(point, false);
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

        private void drawPoint(Point point, bool isActualPosition)
        {
            checkResizePossibility(point);

            Ellipse ellipse = new Ellipse();
            ellipse.Height = diameterPoint;
            ellipse.Width = diameterPoint;
            ellipse.StrokeThickness = 1;
            /*
            if (isActualPosition)
            {
                ellipse.Fill = System.Windows.Media.Brushes.Yellow;
            }
            else
            {
                ellipse.Fill = System.Windows.Media.Brushes.Green;
            }
            */
            ellipse.Fill = System.Windows.Media.Brushes.Green;
            ellipse.Stroke = System.Windows.Media.Brushes.Black;

            Canvas.SetLeft(ellipse, pointPositionX(point.X));
            Canvas.SetTop(ellipse, pointPositionY(point.Y));

            ObjectCollection.Add(ellipse);
        }

        public double pointPositionX(double number) { return (CanvasCenter.X + (number * ScalePoint + ResizeX)); }

        public double pointPositionY(double number) { return (CanvasCenter.Y + (number * ScalePoint + ResizeY)); }

        public Boolean comparePoitInListWithRederedPoint(Point pointFromList, System.Windows.Point pointFromCanvas)
        {
            return (((pointPositionX(pointFromList.X) <= pointFromCanvas.X) && ((pointPositionX(pointFromList.X) + diameterPoint) >= pointFromCanvas.X)) &&
            ((pointPositionY(pointFromList.Y) <= pointFromCanvas.Y) && ((pointPositionY(pointFromList.Y) + diameterPoint) >= pointFromCanvas.Y)));
        }

        private void drawLine(Point point1, Point point2)
        {
            System.Windows.Shapes.Line l = new System.Windows.Shapes.Line();
            l.X1 = CanvasCenter.X + ((point1.X * ScalePoint + diameterPoint / 2) + ResizeX);
            l.X2 = CanvasCenter.X + ((point2.X * ScalePoint + diameterPoint / 2) + ResizeX);
            l.Y1 = CanvasCenter.Y + ((point1.Y * ScalePoint + diameterPoint / 2) + ResizeY);
            l.Y2 = CanvasCenter.Y + ((point2.Y * ScalePoint + diameterPoint / 2) + ResizeY);
            l.Stroke = System.Windows.Media.Brushes.Red;
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
    }
}