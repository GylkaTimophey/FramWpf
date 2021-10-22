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
using System.Collections.ObjectModel;

namespace FramWpf.ViewModel {
    public class ShapesInfo : BindableBase {
        internal static int count = 1;
        public int Id {
            get; set;
        }
    }
    public class LineInfo : ShapesInfo {
        #region constructors
        internal LineInfo() {
            Id = count++;
        }
        public LineInfo(Point startPoint, Point endPoint, Brush brush, bool nextID = true) {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Brush = brush;
            if (nextID) {
                Id = count++;
            }
        }
        public LineInfo(Point startPoint, Point endPoint, Brush brush, int id) {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Brush = brush;
            Id = id;
        }
        public LineInfo(LineInfo info) {
            StartPoint = info.StartPoint;
            EndPoint = info.EndPoint;
            Id = info.Id;
            Brush = info.Brush;
        }
        #endregion
        #region properties
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
        #endregion
    }
    public class EllipseInfo : ShapesInfo {
        #region properties
        public double radius {
            get; set;
        }
        public Brush brush {
            get; set;
        }
        public Thickness margin {
            get; set;
        }
        #endregion
    }
}
