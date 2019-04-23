using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_WpfApp
{
    public class Point
    {
        double x;
        double y;
        double course;
        int msgNumber;
        DateTime receiptTime;

        public static bool isNewPoint = true;

        public Point(double x, double y) { X = x; Y = y; }
        public Point(double x, double y, int msgNumber) { X = x; Y = y; MsgNumber = msgNumber; }
        public Point(double x, double y, int msgNumber, double course, DateTime receiptTime) { X = x; Y = y; MsgNumber = msgNumber; Course = course; ReceiptTime = receiptTime; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public int MsgNumber { get => msgNumber; set => msgNumber = value; }
        public double Course { get => course; set => course = value; }
        public DateTime ReceiptTime { get => receiptTime; set => receiptTime = value; }
    }

    public class RunTrack
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Point normalizationPoint;
        private double positionRadius = 5;
        private double vectorRadius = 10;
        private Point detectedStartRunPoint = null;

        public Point NormalizationPoint { get => normalizationPoint; set => normalizationPoint = value; }
        public double PositionRadius { get => positionRadius; set => positionRadius = value; }
        public double VectorRadius { get => vectorRadius; set => vectorRadius = value; }
        public Point DetectedStartRunPoint { get => detectedStartRunPoint; set => detectedStartRunPoint = value; }

        public List<Point> pointList = new List<Point>();
        public Queue<Point> pointQueue = new Queue<Point>();
        internal void addNewGpsMsg(GPSData gPSData, int msgNumber, DateTime receiptTime)
        {
            if (pointList.Count == 0)
            {
                NormalizationPoint = new Point(gPSData.latitude, gPSData.longitude);
                Point p = new Point(gPSData.latitude - NormalizationPoint.X, gPSData.longitude - NormalizationPoint.Y, msgNumber, gPSData.course, receiptTime);
                checkNewLap(p);
                pointList.Add(p);
                pointQueue.Enqueue(p);
            }
            else
            {
                Point p = new Point(gPSData.latitude - NormalizationPoint.X, gPSData.longitude - NormalizationPoint.Y, msgNumber, gPSData.course, receiptTime);
                checkNewLap(p);
                pointList.Add(p);
                pointQueue.Enqueue(p);
            }
        }

        private void checkNewLap(Point newPoint)
        {
            if (DetectedStartRunPoint == null)
            {
                foreach (Point oldPoint in pointList) //mozno neprechadzat cele pole ale iba x sprav na zaciatky
                {
                    if (Convert.ToDouble((newPoint.ReceiptTime - oldPoint.ReceiptTime).TotalSeconds.ToString()) > 10)
                    {
                        if (isInPositionRadius(oldPoint, newPoint))
                        {
                            if (isInDirectionVectorRadius(oldPoint, newPoint))
                            {
                                if (DetectedStartRunPoint == null)
                                {
                                    DetectedStartRunPoint = newPoint;
                                    AppController.get.SelectedDiscipline.detectedNewRun(newPoint.ReceiptTime);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (Convert.ToDouble((newPoint.ReceiptTime - DetectedStartRunPoint.ReceiptTime).TotalSeconds.ToString()) > 10) //nie je to hned dalsia sprava v radiuse - malo by to byt nastavidelne podla prejdenej vzdialenosti
                {
                    if (isInPositionRadius(DetectedStartRunPoint, newPoint))
                    {
                        if (isInDirectionVectorRadius(DetectedStartRunPoint, newPoint))
                        {
                            log.Info("Next Run was detected");
                            DetectedStartRunPoint = newPoint;
                            AppController.get.SelectedDiscipline.detectedNewRun(newPoint.ReceiptTime);
                        }
                    }
                }
            }
        }

        internal void clear()
        {
            pointList.Clear();
            pointQueue.Clear();
        }

        private bool isInDirectionVectorRadius(Point oldPoint, Point newPoint) { return ((newPoint.Course > (oldPoint.Course - VectorRadius)) && (newPoint.Course < (oldPoint.Course + VectorRadius))); }

        private bool isInPositionRadius(Point oldPoint, Point newPoint) { return ((newPoint.X > (oldPoint.X - PositionRadius)) && (newPoint.X < (oldPoint.X + PositionRadius)) && (newPoint.Y > (oldPoint.Y - PositionRadius)) && (newPoint.Y < (oldPoint.Y + PositionRadius))); }
    }
}
