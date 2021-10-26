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
using System.Windows.Shapes;
using System.Collections.Specialized;

namespace FramWpf.ViewModel {
    public class ShapesVM : BindableBase {

        readonly Class1 model = new Class1();
        public static int EllipseRadius = 10;
        public static int EllipseDiameter = EllipseRadius*2;

        internal static Dictionary<Point, List<(int, Destination)>> NodeList;

        public ShapesVM() {
            ShapesInfoList.CollectionChanged += ShapesInfoListChanged;
            model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            NodeList = new Dictionary<Point, List<(int, Destination)>>();
            ShapesList = new ObservableCollection<Shape>();
            //ShapesInfoList.Add(new EllipseInfo());
            //ShapesInfoList.Add(new LineInfo(new Point(0, 100), new Point(0, 200), Brushes.Violet));
            //ShapesInfoList.Add(new LineInfo() { shape = new Line() { X1 = 0, X2 = 500, Y1 = 300, Y2 = 100, Stroke = Brushes.Violet, StrokeThickness = 5 } });
            //ShapesInfoList.Add(new ShapesInfo() { shape = new Line() { X1 = 0, X2 = 500, Y1 = 100, Y2 = 100, Stroke = Brushes.Black, StrokeThickness = 5 } });
            //ShapesInfoList.Add(new ShapesInfo() { shape = new Line() { X1 = 0, X2 = 500, Y1 = 200, Y2 = 200, Stroke = Brushes.Red, StrokeThickness = 5 } });
            //ShapesInfoList.Add(new ShapesInfo() { shape = new Ellipse() { Margin = new Thickness(100, 10, 0, 0), Stroke = Brushes.Red, StrokeThickness = 10 } });
            //ShapesInfoList.Add(new EllipseInfo(20, 40, Brushes.Violet, new Thickness(100,100,0,0)));

        }
        public static ObservableCollection<Shape> ShapesList {
            get; set;
        }
        public static ObservableCollection<ShapeInfo> ShapesInfoList => Class1.myValues;
        public void ShapesInfoListChanged(object sender, NotifyCollectionChangedEventArgs e) {
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    ShapesList.Add((e.NewItems[0] as ShapeInfo).shape);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    ShapesList.Remove((e.OldItems[0] as ShapeInfo).shape);
                    break;
            }
        }
        public enum Destination {
            StartPoint, EndPoint
        }

    }
}
