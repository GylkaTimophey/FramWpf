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
    public class ShapeInfo : BindableBase {
        internal virtual Shape shape {
            get;
            set;
        }
        internal static int count = 0;
        public int Id {
            get; set;
        }
    }
    public class LineInfo : ShapeInfo {
        #region constructors
        internal LineInfo() {
            Id = count++;
            shape = new Line() { StrokeThickness = 5};
        }
        public LineInfo(Point startPoint, Point endPoint, Brush brush) {
            shape =
                new Line() {
                    X1 = startPoint.X,
                    Y1 = startPoint.Y,
                    X2 = endPoint.X,
                    Y2 = endPoint.Y,
                    Stroke = brush,
                    StrokeThickness = 5
                };
            StartPoint = startPoint;
            EndPoint = endPoint;
            Brush = brush;
            Id = count++;
        }
        //for develop
        public LineInfo(LineInfo info) {
            StartPoint = info.StartPoint;
            EndPoint = info.EndPoint;
            Id = info.Id;
            Brush = info.Brush;
            shape = info.shape;
        }
        #endregion
        #region properties
        private Point startPoint;
        public Point StartPoint {
            get {
                return startPoint;
            }
            set {
                ((Line)shape).X1 = value.X;
                ((Line)shape).Y1 = value.Y;
                startPoint = value;
            }
        }
        private Point endPoint;
        public Point EndPoint {
            get {
                return endPoint;
            }
            set {
                ((Line)shape).X2 = value.X;
                ((Line)shape).Y2 = value.Y;
                endPoint = value;
            }
        }
        private Brush brush;
        public Brush Brush {
            get {
                return brush;
            }
            set {
                shape.Stroke = value;
                brush = value;
            }
        }
        #endregion
    }
    public class EllipseInfo : ShapeInfo {
        public EllipseInfo() {
            shape = new Ellipse();
            shape.Opacity = 0.4;
            Id = count++;
        }
        public EllipseInfo(int width, int height, Brush brush, Thickness margin) {
            shape = new Ellipse();
            shape.Opacity = 0.4;
            Width = width;
            Height = height;
            Brush = brush;
            Margin = margin;
            Id = count++;
        }
        #region properties
        public int width;
        public int Width {
            get {
                return width;
            }
            set {
                width = value;
                shape.Width = value;
            }
        }
        public int height;
        public int Height {
            get {
                return height;
            }
            set {
                height = value;
                shape.Height = value;
            }
        }
        public Brush brush;
        public Brush Brush {
            get {
                return brush;
            }
            set {
                brush = value;
                shape.Fill = value;
            }
        }
        public Thickness margin;
        public Thickness Margin {
            get {
                return margin;
            }
            set {
                margin = value;
                shape.Margin = value;
            }
        }
        #endregion
    }
}
