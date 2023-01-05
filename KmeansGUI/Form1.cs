using KmeansGUI;
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
    public partial class Form1 : Form
    {
        private int _countCluster = 0;
        private int _countIteration = 0;
        public Form1()
        {
            InitializeComponent();
            //Создание таблицы входных данных. Связывается с dataGridView
            InputTable table = new InputTable(dataGridView1);
            //Назначаются начальные настройки для таблицы
            table.DefaultValues();
        }

        public async void RunKMeans()
        {
            text_Console.Text = "";
            graphicsPage1.ResetGraphics();
            _countCluster = (int)kmeans_num.Value;
            //Считывание данных с заполненной таблицы
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                //Создание зубчатого массива
                Point[][] jaggedPoint = CreateJaggedArray(i);
                //Добавление результатов нахождения позиции объета на плоскость
                var point = FindPoint(jaggedPoint);
                point.Position.Y /= 5;
                graphicsPage1.AddPoint(point);
            }

            CreateCentroid();

            bool isDone = false;
            _countIteration = 0;
            while (!isDone)
            {
                await Task.Delay(1000); //Ожидание
                graphicsPage1.Drow();

                _countIteration++;
                //Работает, пока есть свободные поинты
                bool isFreePoints = true;
                while (isFreePoints)
                {
                    isFreePoints = graphicsPage1.PickUpPoints();
                }
                await Task.Delay(1000); //Ожидание
                graphicsPage1.Drow();

                bool isComparison = true; //Старый список совпадает с новым
                if (!isFreePoints)
                {
                    //Сверка старого списка
                    isComparison = graphicsPage1.ComparisonNewPointsAndOldPoints();
                    //Если старый список не совпадает с новым, то перезаписать новые значения в старые
                    if (!isComparison)
                    {
                        ShowRatios();
                        graphicsPage1.DublicatePoints();
                        //Вернуть к базовым параметрам поинты
                        graphicsPage1.SetDefaultPoints();
                        //Очистить список пренадлежавших поинтов
                        graphicsPage1.SetDefaultCentroids();
                    }
                }

                if (isComparison) //Если старый список совпадает с предыдущим, то работа выполннена
                {
                    isDone = true;
                }
            }

            Debug.WriteLine("Кол-во итераций: " + _countIteration); //Для дебага
        }

        //Создание зубчатого массива
        public Point[][] CreateJaggedArray(int numRow)
        {
            Point[][] jaggedArray = new Point[5][];
            int count = jaggedArray.Length;
            for(int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new Point[count];
                //Инициализация массива
                for(int j = 0; j < count; j++)
                {
                    jaggedArray[i][j] = new Point();
                }
                count--;
            }

            bool isX = false;

            //Заполнение данными
            for(int i = 0; i < jaggedArray.Length; i++)
            {
                //Cells[i+1] i+1 потому что первое идёт название
                string value = dataGridView1.Rows[numRow].Cells[i+1].Value.ToString();
                int resultValue = 0;
                bool isResult = int.TryParse(value, out resultValue);
                if (!isResult) {
                    switch (value)
                    {
                        /*Для слов Да и Нет можно назначить любые значения*/
                        /*для корректировки их позиции в плоскости*/
                        case "Да":
                            resultValue = 100;
                            break;
                        case "Нет":
                            resultValue = 200;
                            break;
                    }
                }

                if (!isX)
                {
                    jaggedArray[0][i].Position.X = resultValue;
                    isX = true;
                }
                else
                {
                    jaggedArray[0][i].Position.Y = resultValue;
                    isX = false;
                }
            }

            return jaggedArray;
        }

        public Point FindPoint(Point[][] values)
        {
            for(int i = 0; i < values.Length-1; i++)
            {
                for(int j = 0; j < values[i].Length-1; j++)
                {
                    values[i + 1][j].Position.X = (values[i][j].Position.X + values[i][j + 1].Position.X)/2;
                    values[i + 1][j].Position.Y = (values[i][j].Position.Y + values[i][j + 1].Position.Y)/2;
                }
            }

            return values[values.Length-1][0];
        }

        public void CreateCentroid()
        {
            Vector2 beginPos = new Vector2();
            for (int i = 0; i < _countCluster; i++)
            {
                Centroid centroid = new Centroid(i);
                centroid.Position = new Vector2(beginPos.X, beginPos.Y);
                graphicsPage1.AddCentroid(centroid);
                beginPos.X += _countCluster * 100;
                beginPos.Y += _countCluster * 100;
            }
        }


        /// <summary>
        /// Показать соотношения
        /// </summary>
        public void ShowRatios()
        {
            text_Console.Text += "--------------Иттерация №" + _countIteration + "--------------\n";
            List<Point> points = graphicsPage1.GetPoints;
            for(int i = 0; i < points.Count; i++)
            {
                text_Console.Text += dataGridView1.Rows[i].Cells[0].Value.ToString() + " относится к кластеру " + points[i].BelongsCentroid.Color.Color.ToString() + "\n";
            }
        }

        private void btn_generateDraw_Click(object sender, EventArgs e)
        {
            RunKMeans();
        }
    }
}

public class Point
{
    public Vector2 Position;
    public Pen pen = Pens.Black; //Цвет
    public Centroid BelongsCentroid; //Принадлежит центру

    public Point()
    {
        Position = new Vector2();
    }

    public Point(Centroid centroid)
    {
        Position = new Vector2();
        BelongsCentroid = centroid;
    }

    public Point(Point dublicatePoint)
    {
        Position = new Vector2(dublicatePoint.Position.X, dublicatePoint.Position.Y);
        pen = dublicatePoint.pen;
        BelongsCentroid = dublicatePoint.BelongsCentroid;
    }

    /// <summary>
    /// Сравнивает объекты и возвращает результат
    /// </summary>
    /// <returns>true-объеты схожи, false-объекты разные</returns>
    public bool Comparison(Point point)
    {
        if(!(Position.X == point.Position.X) && (Position.Y == point.Position.Y))
        {
            return false;
        }

        if (pen != point.pen)
        {
            return false;
        }

        if(BelongsCentroid != point.BelongsCentroid)
        {
            return false;
        }

        return true;
    }
}

public class Vector2
{
    public float X;
    public float Y;

    public Vector2()
    {
        X = 0;
        Y = 0;
    }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }
}
