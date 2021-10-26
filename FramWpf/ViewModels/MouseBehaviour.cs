using FramWpf.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FramWpf.ViewModel {
    public class MouseBehaviour : Behavior<Panel> {
        #region adding
        private static void NotifyStaticPropertyChanged(string propertyName) {
            if (StaticPropertyChanged != null)
                StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
        }
        public static readonly DependencyProperty MouseYProperty = DependencyProperty.Register(
           "MouseY", typeof(double), typeof(MouseBehaviour), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty MouseXProperty = DependencyProperty.Register(
           "MouseX", typeof(double), typeof(MouseBehaviour), new PropertyMetadata(default(double)));
        #endregion
        #region properties
        public DelegateCommand LeftClick {
            get; set;
        }
        public DelegateCommand ClearButton {
            get; set;
        }
        public DelegateCommand BackStep {
            get; set;
        }

        public MouseBehaviour() {
            BackStep = new DelegateCommand(UserEventHandler.BackStep);
            LeftClick = new DelegateCommand(ToolBarControls.Drawing);
            ClearButton = new DelegateCommand(ToolBarControls.Clear);
        }

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        public static bool Move;
        public static bool Line;

        public static bool IsMoveChecked {
            get {
                return Move;
            }
            set {
                Move = value;
                NotifyStaticPropertyChanged("IsMoveChecked");
                if (IsMoveChecked) {
                    IsLineChecked = false;
                }
            }
        }

        public static bool IsLineChecked {
            get {
                return Line;
            }
            set {
                Line = value;
                NotifyStaticPropertyChanged("IsLineChecked");
                if (IsLineChecked) {
                    IsMoveChecked = false;
                }
            }
        }

        public double MouseY {
            get {
                return (double)GetValue(MouseYProperty);
            }
            set {
                SetValue(MouseYProperty, value);
            }
        }
        public double MouseX {
            get {
                return (double)GetValue(MouseXProperty);
            }
            set {
                SetValue(MouseXProperty, value);
            }
        }
        #endregion
        #region fields
        public static Point position;
        #endregion
        #region methods

        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs mouseEventArgs) {
            position = mouseEventArgs.GetPosition(AssociatedObject);
            MouseX = position.X;
            MouseY = position.Y;
            if (!ToolBarControls.endNodeMoving) {
                ToolBarControls.NodeCheck(position);
            }
            if (ToolBarControls.endDrawing) {
                ((LineInfo)ShapesVM.ShapesInfoList[ToolBarControls.currentLineInfo.Id]).EndPoint = position;
            }
            if (IsMoveChecked && ToolBarControls.endLineMoving) {
                ((LineInfo)ShapesVM.ShapesInfoList[ToolBarControls.currentId]).StartPoint = new Point(position.X - ToolBarControls.startDiff.X, position.Y - ToolBarControls.startDiff.Y);
                ((LineInfo)ShapesVM.ShapesInfoList[ToolBarControls.currentId]).EndPoint = new Point(position.X - ToolBarControls.endDiff.X, position.Y - ToolBarControls.endDiff.Y);
                ((LineInfo)ShapesVM.ShapesInfoList[ToolBarControls.currentId]).Brush = Brushes.Green;
            }
            if (IsMoveChecked && ToolBarControls.endNodeMoving) {
                ShapesVM.ShapesInfoList[0] = (new EllipseInfo(ShapesVM.EllipseDiameter, ShapesVM.EllipseDiameter, Brushes.Gold, new Thickness(position.X - ShapesVM.EllipseRadius, position.Y - ShapesVM.EllipseRadius, 0, 0)));
                foreach ((int, ShapesVM.Destination) id in ToolBarControls.ListID) {
                    switch (id.Item2) {
                        case ShapesVM.Destination.StartPoint:
                            ((LineInfo)ShapesVM.ShapesInfoList[id.Item1]).StartPoint = new Point(position.X, position.Y);
                            break;
                        case ShapesVM.Destination.EndPoint:
                            ((LineInfo)ShapesVM.ShapesInfoList[id.Item1]).EndPoint = new Point(position.X, position.Y);
                            break;
                    }
                }
            }
        }

        #endregion


        protected override void OnAttached() {
            AssociatedObject.MouseMove += AssociatedObjectOnMouseMove;
        }
        protected override void OnDetaching() {
            AssociatedObject.MouseMove -= AssociatedObjectOnMouseMove;
        }
    }
}
