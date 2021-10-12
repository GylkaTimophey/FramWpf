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
    class RoderLineList : BindableBase {
        public static ObservableCollection<RoderLine> lineList;
        public ObservableCollection<RoderLine> LineList {
            get {
                return lineList;
            }
            set {
                lineList = value;
                OnPropertyChanged("LineList");
            }
        }
        private event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DelegateCommand<ItemsControl> LeftClick {get;set;}
        public RoderLineList() {
            lineList = new ObservableCollection<RoderLine>();
            LeftClick = new DelegateCommand<ItemsControl>(Drawing);
            lineList.Add(new RoderLine(new Point(250, 250), new Point(400, 250), Brushes.Red));
            lineList.Add(new RoderLine(new Point(50, 50), new Point(0, 50), Brushes.Black));
            lineList.Add(new RoderLine(new Point(100, 100), new Point(0, 100), Brushes.Violet));
            lineList.Add(new RoderLine(new Point(150, 150), new Point(0, 150), Brushes.Blue));
            lineList.Add(new RoderLine(new Point(200, 200), new Point(0, 200), Brushes.DarkGreen));
        }

        private RoderLine currentRoderLine;
        bool endDrawing;
        public void Drawing(ItemsControl control) {
            Point point = new Point();
            if (endDrawing) {
                endDrawing = false;
                EndDrawing(point);
            }
            else {
                endDrawing = true;
                StartDrawing(point);
            }


        }
        private void StartDrawing(Point point) {
            currentRoderLine = new RoderLine(point, new Point(), Brushes.Black);
            LineList.Add(currentRoderLine);
        }
        private void EndDrawing(Point point) {
            LineList[currentRoderLine.Id].EndPoint = point;
        }
    }
}
