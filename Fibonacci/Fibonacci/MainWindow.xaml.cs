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

namespace Fibonacci
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lstResult.Items.Clear();  // 즉시 지워지지 않는 이유는??


            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i <= int.Parse(txtNumber.Text); i++)
            {
                lstResult.Items.Add(Fibonacci(i));
                tbResult.Text = Fibonacci(i).ToString();
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            lstResult.Items.Add("실행시간 = " + elapsedMs + "ms");
        }

        private int Fibonacci(int i)
        {
            if (i == 1 || i == 2)
                return 1;
            else
                return Fibonacci(i - 1) + Fibonacci(i - 2);
        }
    }
}
