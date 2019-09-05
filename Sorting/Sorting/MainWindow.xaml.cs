using System;
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

namespace Sorting
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    const int SIZE = 100000;
    int[] a = new int[SIZE];
    int N;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void BtnCreate_Click(object sender, RoutedEventArgs e)
    {
      N = int.Parse(txtNo.Text);
      Random r = new Random();
      for (int i = 0; i < N; i++)
        a[i] = r.Next();
      PrintArray(a);
    }

    // 버블소트
    private void BtnQuad_Click(object sender, RoutedEventArgs e)
    {
      for (int i = N - 1; i > 0; i--)
        for (int j = 0; j < i; j++)
        {
          if (a[j] > a[j + 1])
          {
            int t = a[j];
            a[j] = a[j + 1];
            a[j + 1] = t;
          }
        }
      PrintArray(a);
    }

    private void PrintArray(int[] a)
    {
      Console.WriteLine("Print a[]");
      for(int i=0; i<10; i++)
        Console.WriteLine(a[i]);
      Console.WriteLine("...");
      for(int i =N-10; i<N; i++)
        Console.WriteLine(a[i]);
    }
  }
}
