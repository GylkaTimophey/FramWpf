using Prism.Commands;
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
        public ObservableCollection<RoderLine> lineList {
            get; set;
        }
        public DelegateCommand LeftClick {
            get; set;
        }
        public RoderLineList() {
            lineList = new ObservableCollection<RoderLine>();
            LeftClick = new DelegateCommand(AddLines);
            lineList.Add(new RoderLine(new Point(250, 250), new Point(400, 250), Brushes.Red));
            lineList.Add(new RoderLine(new Point(50, 50), new Point(0, 50), Brushes.Black));
            lineList.Add(new RoderLine(new Point(100, 100), new Point(0, 100), Brushes.Violet));
            lineList.Add(new RoderLine(new Point(150, 150), new Point(0, 150), Brushes.Blue));
            lineList.Add(new RoderLine(new Point(200, 200), new Point(0, 200), Brushes.DarkGreen));
        }
        double a, b;
        internal void AddLines() {
            lineList.Add(new RoderLine(new Point(0, 0), new Point(a * a, b), Brushes.Red));
            a += 1;
            b += 10;
        }
    }
}
