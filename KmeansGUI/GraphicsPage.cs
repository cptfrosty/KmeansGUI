using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KmeansGUI
{
    public partial class GraphicsPage : UserControl
    {
        public List<Point> GetPoints { get => points; }
        private Graphics g;
        private List<Point> points = new List<Point>();
        private List<Centroid> centroids = new List<Centroid>();

        private List<Point> oldPoints = new List<Point>();

        public GraphicsPage()
        {
            InitializeComponent();
        }

        public void ResetGraphics()
        {
            points.Clear();
            centroids.Clear();
            oldPoints.Clear();
            g.Clear(Color.White);
        }

        public void AddCentroid(Centroid centroid)
        {
            centroids.Add(centroid);
        }

        public void Drow()
        {
            g.Clear(Color.White);
            g = CreateGraphics();
            GraphicsPage_Paint(null, null);
        }

        public void AddPoint(Point point)
        {
            g = CreateGraphics();
            points.Add(point);
        }

        private void GraphicsPage_Paint(object sender, PaintEventArgs e)
        {
            if (points.Count == 0)
            {
                g = CreateGraphics();
                return;
            }
            g.Clear(Color.White);
            for(int i = 0; i < points.Count; i++)
            {
                //points[i].Position.Y /= 5;
                g.DrawEllipse(points[i].pen, points[i].Position.X, points[i].Position.Y, 10, 10);
            }

            for (int i = 0; i < centroids.Count; i++)
            {
                g.DrawRectangle(centroids[i].Color, centroids[i].Position.X, centroids[i].Position.Y, 10, 10);
            }
        }

        public void SetDefaultPoints() //Очистить поинты
        {
            for(int i = 0; i < points.Count; i++)
            {
                points[i].BelongsCentroid = null;
                points[i].pen = Pens.Black;
            }
        }

        public void SetDefaultCentroids() //Очистить центройды
        {
            for (int i = 0; i < centroids.Count; i++)
            {
                centroids[i].points.Clear();
            }
        }


        /// <summary>
        /// Для центройдов присваивает ячейки
        /// </summary>
        /// <returns>true - есть ещё свободные ячейки, false - свободных ячеек нет</returns>
        public bool PickUpPoints()
        {
            bool result = true;

            //List<Centroid> centroidsTime = new List<Centroid>(centroids);

            for (int c = 0; c < centroids.Count; c++)
            {
                double minDistance = -1;
                int indexCentroid = -1;
                Centroid centroid = null;
                Point point = null;

                for (int i = c; i < centroids.Count; i++)
                {
                    for (int j = 0; j < points.Count; j++)
                    {
                        if (points[j].BelongsCentroid == null)
                        {
                            double distance = Math.Sqrt(Math.Pow(centroids[i].Position.X - points[j].Position.X, 2) + Math.Pow(centroids[i].Position.Y - points[j].Position.Y, 2));
                            if (minDistance == -1 || minDistance > distance)
                            {
                                minDistance = distance;
                                centroid = centroids[i];
                                point = points[j];
                                indexCentroid = i;
                                Debug.WriteLine(centroid.Color.Color.ToString() + " дистанция: " + minDistance);
                            }
                        }
                    }
                }

                if (centroid != null && point != null)
                {
                    centroid.AddPoints(point);
                    centroid.Move();
                    point.BelongsCentroid = centroid;
                    point.pen = centroid.Color;

                    Centroid tmp = centroids[c];
                    centroids[c] = centroids[indexCentroid];
                    centroids[indexCentroid] = tmp;

                    Debug.WriteLine(centroid.Color.Color.ToString() + " дистанция: " + minDistance + " (принятый)");
                }

                if (point == null)
                {
                    result = false;
                    break;
                }
            }

            //Предыдущий алгоритм (был баг: не к тому относилась точка)

            /*for (int i = 0; i < centroids.Count; i++)
            {
                Point nearest = null;
                double minDistance = -1;
                for(int j = 0; j < points.Count; j++)
                {
                    if (points[j].BelongsCentroid == null)
                    {
                        double distance = Math.Sqrt(Math.Pow(centroids[i].Position.X - points[j].Position.X, 2) + Math.Pow(centroids[i].Position.Y - points[j].Position.Y, 2));
                        if (nearest == null)
                        {
                            minDistance = distance;
                            nearest = points[j];
                        }
                        else
                        {
                            if (minDistance > distance)
                            {
                                minDistance = distance;
                                nearest = points[j];
                            }
                        }
                    }
                }
                if (nearest == null)
                {
                    result = false;
                    break;
                }
                
                centroids[i].AddPoints(nearest);
                centroids[i].Move();
                nearest.BelongsCentroid = centroids[i];
                nearest.pen = centroids[i].Color;
            }*/

            return result;
        }

        public void DublicatePoints()
        {
            oldPoints.Clear();
            for(int i = 0; i < points.Count; i++)
            {
                Point point = new Point();
                point.Position = new Vector2(points[i].Position.X, points[i].Position.Y);
                point.pen = points[i].pen;
                point.BelongsCentroid = points[i].BelongsCentroid;
                oldPoints.Add(point);
            }
        }

        public bool ComparisonNewPointsAndOldPoints()
        {
            return ComparisonPoints(oldPoints, points);
        }

        //Сравнение двух списков
        private bool ComparisonPoints(List<Point> points1, List<Point> points2)
        {
            if (points1.Count == 0 || points2.Count == 0) return false;

            bool result = true;
            for(int i = 0; i < points1.Count; i++)
            {
                if (!points1[i].Comparison(points2[i]))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
