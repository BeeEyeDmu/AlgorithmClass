using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GraphWPF
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    int[] a = new int[100];
    int N = 100;
    const int Max = 1000;
    Thread t1 = null;

    public MainWindow()
    {
      InitializeComponent();
    }

    // 버블정렬
    private void BubbleClick(object sender, RoutedEventArgs e)
    {
      t1 = new Thread(Bubble);
      t1.Start();
    }

    // t1 쓰레드가 실행하는 정렬함수
    private void Bubble()
    {
      for (int i = 0; i < N - 1; i++)
      {
        for (int j = i + 1; j < N; j++)
          if (a[i] > a[j])
          {
            int tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
          }
        Dispatcher.Invoke(new Action(Graph));
        Thread.Sleep(50);
      }
    }

    // 랜덤 생성
    private void RandomClick(object sender, RoutedEventArgs e)
    {
      N = int.Parse(txtNo.Text);
      Random r = new Random();
      for (int i = 0; i < N; i++)
        a[i] = r.Next(Max);
      
      Graph();
    }

    // a[]의 내용을 그래프로 그리는 메서드
    private void Graph()
    {
      canvas1.Children.Clear();
      for(int i=0; i<N; i++)
      {
        Rectangle r = new Rectangle();
        r.Width = 5;
        r.Height 
          = (int)(canvas1.Height * a[i]/(double)Max);
        r.Fill = Brushes.Blue;
        Canvas.SetBottom(r, 0);
        Canvas.SetLeft(r, i * 6);
        canvas1.Children.Add(r);
      }
    }
  }
}
