using Prism.Commands;
using Prism.Mvvm;
using FramWpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Interactivity;

namespace FramWpf.ViewModel {
    public class ShapesVM : BindableBase {
        readonly Class1 model = new Class1();
        public static int radius = 20;

        internal static Dictionary<Point, List<(int, Destination)>> NodeList;

        public ShapesVM() {
            model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            NodeList = new Dictionary<Point, List<(int, Destination)>>();

            ShapesInfoList.Add(new EllipseInfo() { radius = radius });

            //lineList.Add(new RoderLine(new Point(50, 50), new Point(0, 50), Brushes.Black));
            //lineList.Add(new RoderLine(new Point(100, 100), new Point(0, 100), Brushes.Violet));
            //lineList.Add(new RoderLine(new Point(150, 150), new Point(0, 150), Brushes.Blue));
            //lineList.Add(new RoderLine(new Point(200, 200), new Point(0, 200), Brushes.DarkGreen));

        }
        public static ObservableCollection<ShapesInfo> ShapesInfoList => Class1.myValues;
        public enum Destination {
        StartPoint,EndPoint}

    }
}
