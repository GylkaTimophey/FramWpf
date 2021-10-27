using FramWpf.ViewModel;
using FramWpf.Model;
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
using System.Collections.ObjectModel;

namespace FramWpf {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Random r = new Random();
        public MainWindow() {
            InitializeComponent();
            for (int i = 0; i < 50; i++) {
                ShapesVM.ShapesInfoList.Add(new LineInfo(new Point(i * 15.6, 0), new Point(i * 15.6, 400), Brushes.Violet));
            }
        }

        private void WorkSpace_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            var A = Control1;
        }

        private void Line_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

        }

        private void WorkSpace_MouseWheel(object sender, MouseWheelEventArgs e) {
            ((LineInfo)ShapesVM.ShapesInfoList[r.Next(0, 50)]).Brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
        }
    }
}
