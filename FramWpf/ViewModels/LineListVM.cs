using FramWpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using RoderCADUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RoderCADUI.ViewModel {
    //    internal class LineListVM : BindableBase, IValueConverter {
    //        public ObservableCollection<Line> lineListVM {get;set;
    //        }
    //        public RoderLineList roderLineList {
    //            get; set;
    //        }
    //        public DelegateCommand LeftClick {
    //            get; set;
    //        }
    //        double a, b;
    //        public LineListVM() {
    //            roderLineList = new RoderLineList();
    //            LeftClick = new DelegateCommand(AddLines);
    //            lineListVM = new ObservableCollection<Line>();
    //        }
    //        internal void AddLines() {
    //            roderLineList.lineList.Add(new RoderLine(new Point(0, 0), new Point(a, b), Brushes.Red));
    //            lineListVM.Add(ConvertToLine(new RoderLine(new Point(0, 0), new Point(a, b), Brushes.Red)));
    //            a += 10;
    //            b += 10;
    //        }
    //        private ObservableCollection<Line> ConvertToLines(ObservableCollection<RoderLine> RoderLineList) {
    //            var LineList = new ObservableCollection<Line>();
    //            foreach (RoderLine roderLine in RoderLineList) {
    //                LineList.Add(ConvertToLine(roderLine));
    //            }
    //            return LineList;
    //        }
    //        private ObservableCollection<RoderLine> ConvertToRoderLines(ObservableCollection<Line> LineList) {
    //            var RoderLineList = new ObservableCollection<RoderLine>();
    //            foreach (Line line in LineList) {
    //                RoderLineList.Add(ConvertToRoderLine(line));
    //            }
    //            return RoderLineList;
    //        }
    //        internal RoderLine ConvertToRoderLine(Line line) {
    //            RoderLine roderLine = new RoderLine();
    //            roderLine.StartPoint = new Point(line.X1, line.Y1);
    //            roderLine.EndPoint = new Point(line.X2, line.Y2);
    //            roderLine.Brush = line.Stroke;
    //            return roderLine;
    //        }
    //        internal Line ConvertToLine(RoderLine roderLine) {
    //            Line line = new Line();
    //            line.X1 = roderLine.StartPoint.X;
    //            line.X2 = roderLine.EndPoint.X;
    //            line.Y1 = roderLine.StartPoint.Y;
    //            line.Y2 = roderLine.EndPoint.Y;
    //            line.Stroke = roderLine.Brush;
    //            return line;
    //        }

    //        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    //            return ConvertToLines((ObservableCollection<RoderLine>)value);
    //        }
    //        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    //            throw new NotImplementedException();
    //        }
    //    }
}
