using DefectChart.Helper;
using DefectChart.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DefectChart.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ResultPkg _result;
        private UserControl myContent;
        
        
        public UserControl MyContent
        {
            get { return myContent; }
            set { myContent = value; RaisePropertyChanged(() => MyContent); }
        }

        public ResultPkg Result
        {
            get { return _result; }
            set
            {
                if (_result == value) return;
                _result = value;
                RaisePropertyChanged(() => Result);
                OnResultChanged();
                
            }
        }

        // ClsId��Ӧ��
        public static readonly List<string> clsnms = new List<string>() { "_background_", "rectangle", "triangle", "circle" };

        // ͼ������Դ
        public ObservableCollection<BoxItem> Boxes { get; set; } = new ObservableCollection<BoxItem>();

        // ͼ��ˢ���¼�
        public delegate void ResultChangedEventHandler();
        public event ResultChangedEventHandler ResultChanged;
        protected virtual void OnResultChanged()
        {
            if (ResultChanged != null)
            {
                ResultChanged.Invoke();
            }
        }

        public MainViewModel()
        {
            ResultChanged += RefreshChart;
            //��ʼ���û��ؼ�
            this.MyContent = new Chart();
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                {
                    Boxes.Add(new BoxItem() { Height = 100, Width = 100, Left = 100, Top = 100, ClsId = 1});
                });
            });
            //��ȡԤ���
            CommandPkg commandPkg = new CommandPkg()
            {
                Command = "predict",
                Params = ""
            };
            SocketHelper socketHelper = new SocketHelper("127.0.0.1", 50001, commandPkg);
            Task recv_task = Task.Run(() => this.Result = socketHelper.RecvPkg(socketHelper.Connect()));
        }

        /// <summary>
        /// ����Resultˢ��ͼ������
        /// </summary>
        private void RefreshChart()
        {
            ObservableCollection<BoxItem> boxes = new ObservableCollection<BoxItem>();
            foreach (List<double> finalbox in Result.Final_boxes)
            {
                int index = 0;
                double ymin = finalbox[0];
                double xmin = finalbox[1];
                double ymax = finalbox[2];
                double xmax = finalbox[3];
                boxes.Add(CoordTansfer.Transformer(xmin, ymin, xmax, ymax, Result.Final_class_ids[index]));
            }
            Console.WriteLine(boxes.Count);
            //�������������
            App.Current.Dispatcher.BeginInvoke((Action)delegate ()
            {
                Boxes.Clear();
                foreach(BoxItem box in boxes)
                {
                    Boxes.Add(box);
                }
            });
        }

    }

}