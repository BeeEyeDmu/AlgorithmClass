using System;
using System.Collections;
using System.Collections.Generic;
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

namespace ClosestPair
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    // IComparer는 비교를 위한 인터페이스이다
    public class XComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (int)(((Point)x).X - ((Point)y).X);
        }
    }

    public class YComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (int)(((Point)x).Y - ((Point)y).Y);
        }
    }

    public partial class MainWindow : Window
    {
        const int P = 100;
        Point[] points = new Point[P];

        public MainWindow()
        {
            InitializeComponent();
        }

        // 생성
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();
            MakePointArray();
            SortPointArray();   // 점의 배열을 만들고 바로 정렬합니다.
        }

        private void SortPointArray()
        {
            IComparer xComp = new XComparer();
            Array.Sort(points, xComp);
            //Array.Sort(points, new XComparer());
            PrintPoints();
        }

        private void MakePointArray()
        {
            Random r = new Random();

            for (int i = 0; i < P; i++)
            {
                points[i].X = r.Next(1100);
                points[i].Y = r.Next(500);
            }

            foreach (var p in points)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 3;
                rect.Height = 3;
                rect.Stroke = Brushes.Black;
                Canvas.SetLeft(rect, p.X - 1);
                Canvas.SetTop(rect, p.Y - 1);

                canvas1.Children.Add(rect);
            }
        }

        // 찾기버튼(Brute Force 방식)
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // points[] 배열에 있는 점들을
            // x좌표를 기준으로 정렬하여 출력하시오

            // Array.Sort() Test
            //int[] a = new int[100];
            //Random r = new Random();
            //for (int i = 0; i < 100; i++)
            //  a[i] = r.Next(1000);

            //foreach(var v in a)
            //  Console.WriteLine(v);
            //Console.WriteLine("...After Sort");
            //Array.Sort(a);
            //foreach (var v in a)
            //  Console.WriteLine(v);

            //ClosestPair CP = FindClosestPair(points, 0, 100 - 1);
            PointPair result = FindClosestPair(points, 0, P - 1);
            HighLight(result);
            MessageBox.Show(String.Format("({0},{1})-({2},{3}) : {4}",
              result.P1.X, result.P1.Y, result.P2.X, result.P2.Y, result.Dist));

        }

        // Brute Force 방법
        private PointPair FindClosestPair(Point[] points, int left, int right)
        {
            double min = double.MaxValue;
            int minI = 0, minJ = 0;

            // 10개의 배열 각각 요소를 비교 a[10] 
            // a[i]-a[j]의 관계
            // N = 10이라고 하면
            //int N=10;
            //for (int i = 0; i < N - 1; i++)
            //  for (int j = i + 1; j < N; j++)
            //    ;

            for (int i = 0; i < P - 1; i++)
                for (int j = i + 1; j < P; j++)
                {
                    if (Dist(i, j) < min)
                    {
                        min = Dist(i, j);
                        minI = i;
                        minJ = j;
                    }
                }

            PointPair p = new PointPair(points[minI], points[minJ], min);
            //HighLight(p);
            //MessageBox.Show(string.Format("{0}-{1} : {2}", minI, minJ, min));
            return p;

            //if (right - left <= 3)
            //  AlgorithmN2();
            //int mid = left + (right - left) / 2;  // 중앙점
            //ClosestPair CPL = FindClosestPair(points, left, mid);
            //ClosestPair CPR = FindClosestPair(points, mid+1, right);
            //double d = Math.Min(CPL.dist, CPR.dist);
            //ClosestPair CPC = FindMidRange(points, d);

            //return MinCP(CPL, CPR, CPC);
        }

        private void PrintPoints()
        {
            foreach (var p in points)
                Console.WriteLine(p.X + ", " + p.Y);
        }

        //points[i] 와 points[j] 의 거리
        private double Dist(int i, int j)
        {
            // Math.Pow(x, 2) 사용, 또는 x*x
            // Math.Sqrt() 사용
            return Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2) + Math.Pow(points[i].Y - points[j].Y, 2));
        }

        // 분할정복
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PointPair result = FindClosestPairDC(points, 0, P-1);
            HighLight(result);
            MessageBox.Show(String.Format("({0},{1})-({2},{3}) : {4}",
              result.P1.X, result.P1.Y, result.P2.X, result.P2.Y, result.Dist));
        }

        private void HighLight(PointPair result)
        {
            Line line = new Line();
            line.X1 = result.P1.X;
            line.Y1 = result.P1.Y;
            line.X2 = result.P2.X;
            line.Y2 = result.P2.Y;
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 2;
            canvas1.Children.Add(line);
        }

        private PointPair FindClosestPairDC(Point[] points, int left, int right)
        {
            
            if (right - left <= 10)
                return FindClosestPair(points, left, right);

            
            int mid = left + (right - left) / 2;  // 중앙 포인트의 인덱스
            CenterLine(mid);
            Console.WriteLine(string.Format("FindClosestPairtDC({0},{1}) - {2} at {3}", 
                left, right, mid, points[mid].X));

            PointPair CPL = FindClosestPairDC(points, left, mid);
            PointPair CPR = FindClosestPairDC(points, mid + 1, right);
            double d = Math.Min(CPL.Dist, CPR.Dist);
            PointPair CPC = FindMidRange(points, mid, d);

            return MinPointPair(CPL, CPR, CPC);
        }

        private void CenterLine(int mid)
        {
            Line line = new Line();
            line.X1 = points[mid].X;
            line.Y1 = 0;
            line.X2 = points[mid].X;
            line.Y2 = 500;
            line.Stroke = Brushes.Blue;
            canvas1.Children.Add(line);
        }

        // 3개의 PointPair 중에서 가장 dist가 작은 PointPair를 린턴
        private PointPair MinPointPair(PointPair cPL, PointPair cPR, PointPair cPC)
        {
            if (cPL.Dist <= cPR.Dist && cPL.Dist <= cPC.Dist)
                return cPL;
            else if (cPR.Dist <= cPL.Dist && cPR.Dist <= cPC.Dist)
                return cPR;
            else
                return cPC;
        }

        // points[] 배열에서 인덱스가 mid +- d 인 점들 중에서 최소거리쌍을 리턴
        private PointPair FindMidRange(Point[] points, int mid, double d)
        {
            int left = 0, right = 0;

            // 중간영역의 left, right를 찾는다
            for (int i = mid - 1; i >= 0; i--)
                if (points[mid].X - points[i].X > d)
                {
                    left = i;
                    break;
                }

            for (int i = mid + 1; i < points.Length; i++)
                if (points[i].X - points[mid].X > d)
                {
                    right = i;
                    break;
                }

            return FindClosestPair(points, left, right);
        }
    }
}
