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

namespace DefectChart
{
    /// <summary>
    /// Chart.xaml 的交互逻辑
    /// </summary>
    public partial class Chart : UserControl
    {
        public static double Board_Width { get; set; }
        public static double Board_Height { get; set; }
        public Chart()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Board_Width = this.chart_board.ActualWidth;
            Board_Height = this.chart_board.ActualHeight;
        }
    }
}
