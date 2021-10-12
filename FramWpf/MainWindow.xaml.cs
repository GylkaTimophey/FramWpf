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
        public Point MousePosition;
        public MainWindow() {
            InitializeComponent();
        }

        private void WorkSpace_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            var A = Control1;
        }

        private void WorkSpace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            MousePosition = Mouse.GetPosition((IInputElement)sender);
            //Control1.DataContext.LineList.Add(new RoderLine());
        }
    }
}
