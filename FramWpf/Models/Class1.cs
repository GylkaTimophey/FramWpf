using FramWpf.ViewModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FramWpf.Model {
    class Class1 : BindableBase {
        public static ObservableCollection<ShapesInfo> myValues;
        public Class1() {
            List<ShapesInfo> list = new List<ShapesInfo>(200);
            myValues = new ObservableCollection<ShapesInfo>(list);
        }
        private Point startPoint;
        public Point StartPoint {
            get {
                return startPoint;
            }
            set {
                startPoint = value;
            }
        }
        private Point endPoint;
        public Point EndPoint {
            get {
                return endPoint;
            }
            set {
                endPoint = value;
            }
        }
        private Brush brush;
        public Brush Brush {
            get {
                return brush;
            }
            set {
                brush = value;
            }
        }
    }
}
