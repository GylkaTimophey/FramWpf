using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using Prism.Mvvm;
using Prism.Commands;
using System.ComponentModel;

namespace RoderCADUI.Model {
    internal class RoderLine : BindableBase {

        private event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        static int count = 0;
        static int Id;
        internal RoderLine() {
            Id = count++;
        }
        internal RoderLine(Point startPoint, Point endPoint, Brush brush) {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Brush = brush;
            Id = count++;
        }

        private Point startPoint;
        internal Point StartPoint {
            get {
                return startPoint;
            }
            set {
                startPoint = value;
                OnPropertyChanged("roderLine");
            }
        }
        private Point endPoint;
        internal Point EndPoint {
            get {
                return endPoint;
            }
            set {
                endPoint = value;
                OnPropertyChanged("roderLine");
            }
        }
        private Brush brush;
        internal Brush Brush {
            get {
                return brush;
            }
            set {
                brush = value;
                OnPropertyChanged("roderLine");
            }
        }
    }
}
