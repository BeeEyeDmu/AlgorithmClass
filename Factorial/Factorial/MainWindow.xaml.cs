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


namespace Factorial
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
            lstResult.Items.Clear();
            long f = long.Parse(txtNumber.Text);

            lstResult.Items.Add("Recursive Factorial : ");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            lstResult.Items.Add(Factoral(f).ToString("N0"));
            watch.Stop();
            var elapsedTicks = watch.ElapsedTicks;
            lstResult.Items.Add(elapsedTicks.ToString("N0") + " Ticks = "
                + (elapsedTicks / 10000.0).ToString("N") + " ms"); // 1 Tick = 100 ns

            lstResult.Items.Add("\nLoop Factorial : ");
            watch = System.Diagnostics.Stopwatch.StartNew();
            lstResult.Items.Add(RecFact(f).ToString("N0"));
            watch.Stop();
            elapsedTicks = watch.ElapsedTicks;
            lstResult.Items.Add(elapsedTicks.ToString("N0") + " Ticks = "
                + (elapsedTicks / 10000.0).ToString("N") + " ms"); // 1 Tick = 100 ns
        }

        private long RecFact(long f)
        {
            if (f == 1)
                return 1;
            else
                return RecFact(f - 1) * f;
        }

        private long Factoral(long f)
        {
            long fact = 1;
            for (int i = 1; i <= f; i++)
                fact *= i;
            return fact;
        }
    }
}

