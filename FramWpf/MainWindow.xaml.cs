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
        int a = 0;
        public MainWindow() {
            InitializeComponent();
        }

        private void WorkSpace_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
           
            var A = Control1;
        }

        private void Line_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

        }

        private void WorkSpace_MouseWheel(object sender, MouseWheelEventArgs e) {
            if (a < 50) {
                ShapesVM.ShapesInfoList.Add(new LineInfo(new Point(a * 15.6, 0), new Point(a * 15.6, 400), Brushes.Violet));
                a++;
            }
            else if(a < 100) {
                ((LineInfo)ShapesVM.ShapesInfoList[a - 50]).Brush = Brushes.Gray;
                a++;
            }
            else if (a < 150) {
                ((LineInfo)ShapesVM.ShapesInfoList[a - 100]).Brush = Brushes.GreenYellow;
                a++;
            }
            else if (a < 200) {
                ((LineInfo)ShapesVM.ShapesInfoList[a - 150]).Brush = Brushes.Crimson;
                a++;
            }
            else if (a < 250) {
                ((LineInfo)ShapesVM.ShapesInfoList[a - 200]).Brush = Brushes.SteelBlue;
                a++;
            }
            else if (a < 300) {
                ((LineInfo)ShapesVM.ShapesInfoList[a - 250]).Brush = Brushes.BlueViolet;
                a++;
            }
            else if (a < 350) {
                ((LineInfo)ShapesVM.ShapesInfoList[a - 300]).Brush = Brushes.Goldenrod;
                a++;
            }
            else if (a < 400) {
                ((LineInfo)ShapesVM.ShapesInfoList[a - 350]).Brush = Brushes.Fuchsia;
                a++;
            }
        }
    }
}
