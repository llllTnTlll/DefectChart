using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DefectChart.Model
{
    public class BoxItem : ObservableObject
    {
        private int clsId;

        public double Left { get; set; }
        public double Top { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public int ClsId
        {
            get { return clsId; }
            set
            {
                clsId = value;
                RaisePropertyChanged(()=> ClsId);
                RaisePropertyChanged(()=> ClsName);
                RaisePropertyChanged(()=> ClsColor);
            }
        }

        public string ClsName
        {
            get
            {
                return ViewModel.MainViewModel.clsnms[ClsId];
            }
        }

        public Brush ClsColor
        {
            get
            {
                // 修改此处以改变不同实例对应颜色
                // 其顺序对应MainVM中的List
                List<Brush> brushes = new List<Brush>();
                brushes.Add(new SolidColorBrush(Color.FromRgb(255, 255, 255)));
                brushes.Add(new SolidColorBrush(Color.FromRgb(179, 238, 58)));    //rectangle
                brushes.Add(new SolidColorBrush(Color.FromRgb(255, 215, 0)));     //triangle
                brushes.Add(new SolidColorBrush(Color.FromRgb(238, 99, 99)));    //circle
                return brushes[ClsId];
            }
        }

    }
}
