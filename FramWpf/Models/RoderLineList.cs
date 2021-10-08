using Prism.Mvvm;
using RoderCADUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FramWpf.Models {
    class RoderLineList : BindableBase {
        internal ObservableCollection<RoderLine> lineList;
        public RoderLineList() {
            lineList = new ObservableCollection<RoderLine>();
            lineList.Add(new RoderLine(new Point(14, 67), new Point(12,67), Brushes.DarkGreen));
            lineList.Add(new RoderLine(new Point(23, 78), new Point(23, 78), Brushes.DarkGreen));
            lineList.Add(new RoderLine(new Point(34, 89), new Point(34, 89), Brushes.DarkGreen));
            lineList.Add(new RoderLine(new Point(45, 90), new Point(45, 90), Brushes.DarkGreen));
            lineList.Add(new RoderLine(new Point(56, 123), new Point(56, 123), Brushes.DarkGreen));
        }
    }
}
