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
    }

    private void MakePointArray()
    {
      Random r = new Random();

      for(int i=0; i<P; i++)
      {
        points[i].X = r.Next(500);
        points[i].Y = r.Next(500);
      }

      foreach(var p in points)
      {
        Rectangle rect = new Rectangle();
        rect.Width = 3;
        rect.Height = 3;
        rect.Stroke = Brushes.Black;
        Canvas.SetLeft(rect, p.X-1);
        Canvas.SetTop(rect, p.Y-1);

        canvas1.Children.Add(rect);
      }
    }

    // 찾기버튼
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

      Array.Sort(points, new YComparer());
      PrintPoints();
    }

    private void PrintPoints()
    {
      foreach(var p in points)
        Console.WriteLine(p.X + ", " + p.Y);
    }

    // points[i]와 points[j]의 거리
    //private double Dist(int i, int j)
    //{
    //  // Math.Pow(x, 2) 사용, 또는 x*x
    //  // Math.Sqrt() 사용
    //}
  }
}
