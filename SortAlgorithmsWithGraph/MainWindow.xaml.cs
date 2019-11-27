using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Ch2_SortAlgorithms
{
  /// <summary>
  /// 10만개의 정렬: 65초와 31ms 2천배
  /// </summary>
  public partial class MainWindow : Window
  {
    int[] a = new int[100];
    const int sleepTime = 50;

    Thread t1 = null;
    int N = 0;  // 데이터 갯수

    public MainWindow()
    {
      InitializeComponent();
      txtNo.Text = "100";
      N = int.Parse(txtNo.Text);
      UIEnable(false);
      //Dispatcher.Invoke(new Action(delegate { N = int.Parse(txtNo.Text); }));
    }

    private void BtnRandom_Click(object sender, RoutedEventArgs e)
    {
      Random r = new Random();
      for (int i = 0; i < N; i++)
        a[i] = r.Next(10000);

      if(t1 != null)
        t1.Abort();
      Graph();
      PrintArray(a);
      UIEnable(true);
    }

    private void UIEnable(bool v)
    {
      btnRandom.IsEnabled = !v;
      btnHeap.IsEnabled = v;
      btnInsertion.IsEnabled = v;
      btnLog.IsEnabled = v;
      btnQuad.IsEnabled = v;
      btnSelection.IsEnabled = v;
      btnShell.IsEnabled = v;
    }

    // N*N 정렬알고리즘(버블정렬)
    private void BtnQuad_Click(object sender, RoutedEventArgs e)
    {
      UIEnable(false);
      t1 = new Thread(Bubble);
      t1.Start();
    }

    private void Bubble()
    {
      for (int i = N-1; i > 0; i--)
      {
        for (int j = 0; j < i; j++)
        {
          if (a[j] > a[j + 1])
          {
            int t = a[j];
            a[j] = a[j + 1];
            a[j + 1] = t;
          }
        }
        Dispatcher.Invoke(new Action(Graph));
        Thread.Sleep(sleepTime);
      } // for
    }

    private void Graph()
    {
      canvas1.Children.Clear();

      for (int i = 0; i < 100; i++)
      {
        Line l = new Line();
        l.X1 = i * 3;
        l.Y1 = canvas1.Height - (int)(a[i] / (10000.0+100) * canvas1.Height);
        l.X2 = i * 3;
        l.Y2 = canvas1.Height;
        l.HorizontalAlignment = HorizontalAlignment.Left;
        l.VerticalAlignment = VerticalAlignment.Bottom;
        l.Stroke = Brushes.RoyalBlue;
        l.StrokeThickness = 1;
        canvas1.Children.Add(l);
      }
    }

    // NlnN 알고리즘(퀵정렬)
    private void Quick_Sort(int[] arr, int left, int right)
    {
      
      if (left < right)
      {
        int pivot = Partition(arr, left, right);

        if (pivot > 1)
        {
          Quick_Sort(arr, left, pivot - 1);
        }
        if (pivot + 1 < right)
        {
          Quick_Sort(arr, pivot + 1, right);
        }
      }
      Dispatcher.Invoke(new Action(Graph));
      Thread.Sleep(sleepTime);
    }

    private int Partition(int[] arr, int left, int right)
    {
      int pivot = arr[left];
      while (true)
      {
        while (arr[left] < pivot)
        {
          left++;
        }

        while (arr[right] > pivot)
        {
          right--;
        }

        if (left < right)
        {
          if (arr[left] == arr[right])
            return right;

          int temp = arr[left];
          arr[left] = arr[right];
          arr[right] = temp;
        }
        else
        {
          return right;
        }
      }
    }

    private void PrintArray(int[] a)
    {
      for (int i = 0; i < N; i++)
        Console.WriteLine(a[i]);
    }

    private void BtnLog_Click(object sender, RoutedEventArgs e)
    {
      UIEnable(false);
      t1 = new Thread(Quick);
      t1.Start();
    }

    private void Quick()
    {
      Quick_Sort(a, 0, N - 1);
    }

    private void BtnSelection_Click(object sender, RoutedEventArgs e)
    {
      UIEnable(false);
      t1 = new Thread(Selection);
      t1.Start();
    }

    private void Selection()
    {
      int temp, smallest;
      for (int i = 0; i < N; i++)
      {        
        smallest = i;
        for (int j = i + 1; j < N; j++)
        {
          if (a[j] < a[smallest])
          {
            smallest = j;
          }
        }
        temp = a[smallest];
        a[smallest] = a[i];
        a[i] = temp;

        Dispatcher.Invoke(new Action(Graph));
        Thread.Sleep(sleepTime);
      }
      PrintArray(a);
      Console.WriteLine("...After Selection");
    }

    private void BtnInsertion_Click(object sender, RoutedEventArgs e)
    {
      UIEnable(false);
      t1 = new Thread(Insertion);
      t1.Start();
    }

    private void Insertion()
    {
      for (int i = 1; i < N; i++)
      {
        int current = a[i];
        int j = i - 1;
        while(j >= 0 && a[j] > current)
        {
          a[j + 1] = a[j];  // 하나씩 뒤로 옮긴다
          j--;
        }
        a[j + 1] = current;

        Dispatcher.Invoke(new Action(Graph));
        Thread.Sleep(sleepTime);
      }
    }

    private void BtnShell_Click(object sender, RoutedEventArgs e)
    {
      UIEnable(false);
      t1 = new Thread(Shell);
      t1.Start();
    }

    private void Shell()
    {      
      int[] gapArr = {0,  1, 4, 10, 23, 57, 132, 301, 701, 1750 };  //Marcin Ciura

      int gapIndex = 0;
      while (gapArr[gapIndex] < N/2)
        gapIndex++;

      int gap = gapArr[--gapIndex];
      
      while (gap > 0)
      {
        Console.WriteLine("gap = " + gap);
        for (int i = gap; i < N; i++)
        {
          int current = a[i];
          int j = i;
          while (j >= gap && a[j-gap] >current)
          {
            a[j] = a[j - gap];
            j = j - gap;
          }
          a[j] = current;
          Dispatcher.Invoke(new Action(Graph));
          Thread.Sleep(sleepTime);
        }
        gap = gapArr[--gapIndex];        
      }
    }

    private void BtnHeap_Click(object sender, RoutedEventArgs e)
    {
      UIEnable(false);
      t1 = new Thread(Heap);
      t1.Start();
    }

    private void Heap()
    {
      for (int i = N / 2 - 1; i >= 0; i--)
        heapify(a, N, i);

      for (int i = N - 1; i >= 0; i--)
      {
        int temp = a[0];
        a[0] = a[i];
        a[i] = temp;
        heapify(a, i, 0);

        Dispatcher.Invoke(new Action(Graph));
        Thread.Sleep(sleepTime);
      }
    }

    private void heapify(int[] arr, int n, int i)
    {
      int largest = i;
      int left = 2 * i + 1;
      int right = 2 * i + 2;
      if (left < n && arr[left] > arr[largest])
        largest = left;
      if (right < n && arr[right] > arr[largest])
        largest = right;
      if (largest != i)
      {
        int swap = arr[i];
        arr[i] = arr[largest];
        arr[largest] = swap;
        heapify(arr, n, largest);
      }
    }
  }
}