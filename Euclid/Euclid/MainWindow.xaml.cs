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

namespace Euclid
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
        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = "GCD = " + Euclid(Int32.Parse(txtNo1.Text), Int32.Parse(txtNo2.Text)).ToString();
        }

        private int Euclid(int a, int b)
        {
            Console.WriteLine("Euclid({0}, {1})", a, b);
            if (b == 0)
                return a;
            else
                return Euclid(b, a % b);
        }
    }
}
