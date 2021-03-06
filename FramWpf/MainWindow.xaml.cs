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

namespace FramWpf {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void WorkSpace_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            var A = Control1;
        }


        private void Line_MouseDown(object sender, MouseButtonEventArgs e) {
            
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            ToolBarControls.NodeMoving(sender);
        }

        private void Line_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            ToolBarControls.LineChoosing(sender, e.ButtonState);
        }

        private void Line_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            ToolBarControls.LineChoosing(sender, e.ButtonState);
        }
    }
}
