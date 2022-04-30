using DefectChart.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DefectChart.Helper
{
    internal class CoordTansfer
    {
        public static BoxItem Transformer(double xmin, double ymin, double xmax, double ymax, int index)
        {
            double left = xmin;
            double top = ymin;
            double width = xmax - xmin;
            double height = ymax - ymin;
            BoxItem boxItem = new BoxItem() { Left=left, Top=top, Height=height, Width=width, ClsId=index};
            return boxItem;
        }

        
    }

    public class WidthValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double board_width = (double)parameter;
            value = (double)value/512 * board_width;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class HeightValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double board_height = (double)parameter;
            value = (double)value / 512 * board_height;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
