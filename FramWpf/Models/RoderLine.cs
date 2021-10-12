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

namespace FramWpf.Model {
    internal class RoderLine : BindableBase {

        private event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static int count = 0;
        public int Id {
            get;
        }
        internal RoderLine() {
            Id = count++;
        }
        public RoderLine(Point startPoint, Point endPoint, Brush brush, bool nextID = true) {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Brush = brush;
            if (nextID) {
                Id = count++;
            }
        }

        private Point startPoint;
        public Point StartPoint {
            get {
                return startPoint;
            }
            set {
                startPoint = value;
                OnPropertyChanged("roderLine");
            }
        }
        private Point endPoint;
        public Point EndPoint {
            get {
                return endPoint;
            }
            set {
                endPoint = value;
                OnPropertyChanged("roderLine");
            }
        }
        private Brush brush;
        public Brush Brush {
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
