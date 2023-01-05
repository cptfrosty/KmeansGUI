using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmeansGUI
{
    public class Centroid
    {
        public int Id = 0; //Для того, чтобы назначить цвет
        public List<Point> points = new List<Point>();
        public Vector2 Position;
        public Pen Color = Pens.Red;

        public Centroid(int id)
        {
            Id = id;
            switch (id)
            {
                case 0:
                    Color = Pens.Red;
                    break;
                case 1:
                    Color = Pens.Blue;
                    break;
                case 2:
                    Color = Pens.Green;
                    break;
                case 3:
                    Color = Pens.Purple;
                    break;
                case 4:
                    Color = Pens.Orange;
                    break;
                case 5:
                    Color = Pens.Chocolate;
                    break;
            }
        }

        public void AddPoints(Point point)
        {
            points.Add(point);
        }

        public void Move()
        {
            //Нахождение массы системы
            /*Vector2 bigM = new Vector2();
            for(int i = 0; i < points.Count; i++)
            {
                //Сумма векторов
                bigM.X += points[i].Position.X;
                bigM.Y += points[i].Position.Y;
            }*/

            float bigM = 1;
            for (int i = 0; i < points.Count; i++)
            {
                bigM += points[i].Position.X + points[i].Position.Y;
            }

            //Нахождение центра масс
            Vector2 cm = new Vector2();
            float sumX = 0;
            float sumY = 0;
            for (int i = 0; i < points.Count; i++)
            {
                sumX += (points[i].Position.X + points[i].Position.Y) * points[i].Position.X;
                sumY += (points[i].Position.X + points[i].Position.Y) * points[i].Position.Y;
            }
            cm.X = (1.0f / bigM) * sumX;
            cm.Y = (1.0f / bigM) * sumY;

            Position = cm;
        }
    }
}
