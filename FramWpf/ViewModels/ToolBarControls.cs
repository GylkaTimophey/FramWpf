using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FramWpf.ViewModel {
    public static class ToolBarControls {
        public static LineInfo currentLineInfo;
        static Point position {
            get {
                return MouseBehaviour.position;
            }
        }

        #region ClearButton
        public static void Clear() {
            ShapesVM.NodeList = new Dictionary<Point, List<(int, ShapesVM.Destination)>>();
            ShapesVM.ShapesInfoList.Clear();
            ShapesVM.ShapesInfoList.Add(new EllipseInfo());
            ShapeInfo.count = 1;
        }
        #endregion
        #region DrawingButton
        private static bool IsLineChecked {
            get {
                return MouseBehaviour.IsLineChecked;
            }
        }

        public static bool node;
        public static bool endDrawing;
        public static bool newNode;
        public static Point NodePosition;


        public static void Drawing() {

            if (!IsLineChecked) {
                return;
            }
            if (node) {
                if (endDrawing) {
                    endDrawing = false;
                    EndDrawing(NodePosition);
                }
                else if (!endDrawing) {
                    endDrawing = true;
                    StartDrawing(NodePosition);
                }
            }
            else {
                if (endDrawing) {
                    endDrawing = false;
                    EndDrawing(position);
                }
                else if (!endDrawing) {
                    endDrawing = true;
                    StartDrawing(position);
                }
            }
        }
        private static void StartDrawing(Point point) {
            currentLineInfo = new LineInfo(point, point, Brushes.Black);
            AddNode(point, ShapesVM.Destination.StartPoint);
            ShapesVM.ShapesInfoList.Add(currentLineInfo);
            ShapesVM.ShapesInfoList.Add(new EllipseInfo(ShapesVM.EllipseDiameter, ShapesVM.EllipseDiameter, Brushes.Transparent, new Thickness(point.X - ShapesVM.EllipseRadius, point.Y - ShapesVM.EllipseRadius, 0, 0)));
        }
        private static void EndDrawing(Point point) {
            AddNode(point, ShapesVM.Destination.EndPoint);
            currentLineInfo.EndPoint = point;
            currentLineInfo.Brush = Brushes.Black;
            ShapesVM.ShapesInfoList.Add(new EllipseInfo(ShapesVM.EllipseDiameter, ShapesVM.EllipseDiameter, Brushes.Transparent, new Thickness(point.X - ShapesVM.EllipseRadius, point.Y - ShapesVM.EllipseRadius, 0, 0)));
        }
        #endregion
        #region MoveButton

        public static bool endLineMoving;
        public static Point startDiff;
        public static Point endDiff;
        public static int currentId;

        private static bool IsMoveChecked {
            get {
                return MouseBehaviour.IsMoveChecked;
            }
        }

        public static void LineMoving(object sender) {
            if (!IsMoveChecked || endNodeMoving) {
                return;
            }

            if (endLineMoving) {
                endLineMoving = false;
                EndLineMoving();
                return;
            }
            else if (!endLineMoving) {
                Line line = (Line)sender;
                startDiff = new Point(position.X - line.X1, position.Y - line.Y1);
                endDiff = new Point(position.X - line.X2, position.Y - line.Y2);
                StartLineMoving(line);
                endLineMoving = true;
            }
        }
        public static void StartLineMoving(Line line) {
            currentLineInfo = new LineInfo(new Point(line.X1, line.Y1), new Point(line.X2, line.Y2), Brushes.Green);
            currentId = Convert.ToInt32(line.Uid);
        }
        public static void EndLineMoving() {
            ((LineInfo)ShapesVM.ShapesInfoList[currentId]).StartPoint = new Point(position.X - startDiff.X, position.Y - startDiff.Y);
            ((LineInfo)ShapesVM.ShapesInfoList[currentId]).EndPoint = new Point(position.X - endDiff.X, position.Y - endDiff.Y);
            ((LineInfo)ShapesVM.ShapesInfoList[currentId]).Brush = Brushes.Black;
            List<(int, ShapesVM.Destination)> list1 = ShapesVM.NodeList[currentLineInfo.StartPoint];
            List<(int, ShapesVM.Destination)> list2 = ShapesVM.NodeList[currentLineInfo.EndPoint];
            if (ShapesVM.NodeList[currentLineInfo.StartPoint].Count > 1) {
                ShapesVM.NodeList.Add(new Point(position.X - startDiff.X, position.Y - startDiff.Y), new List<(int, ShapesVM.Destination)>() { (currentId, ShapesVM.Destination.StartPoint) });
                list1.Remove((currentId, ShapesVM.Destination.StartPoint));
            }
            else {
                ShapesVM.NodeList.Add(new Point(position.X - startDiff.X, position.Y - startDiff.Y), new List<(int, ShapesVM.Destination)>() { (currentId, ShapesVM.Destination.StartPoint) });
                ShapesVM.NodeList.Remove(currentLineInfo.StartPoint);
            }
            if (ShapesVM.NodeList[currentLineInfo.EndPoint].Count > 1) {
                ShapesVM.NodeList.Add(new Point(position.X - endDiff.X, position.Y - endDiff.Y), new List<(int, ShapesVM.Destination)>() { (currentId, ShapesVM.Destination.EndPoint) });
                list2.Remove((currentId, ShapesVM.Destination.EndPoint));
            }
            else {
                ShapesVM.NodeList.Add(new Point(position.X - endDiff.X, position.Y - endDiff.Y), new List<(int, ShapesVM.Destination)>() { (currentId, ShapesVM.Destination.EndPoint) });
                ShapesVM.NodeList.Remove(currentLineInfo.EndPoint);
            }
        }
        #endregion
        #region NodeMoving
        public static List<(int, ShapesVM.Destination)> ListID;
        public static bool endNodeMoving;
        public static void NodeMoving(object sender) {
            if (!IsMoveChecked || endLineMoving) {
                return;
            }

            if (endNodeMoving) {
                endNodeMoving = false;
                EndNodeMoving();
            }
            else if (!endNodeMoving) {
                Ellipse ellipse = (Ellipse)sender;
                endNodeMoving = true;
                StartNodeMoving(ellipse);
            }
        }
        public static void StartNodeMoving(Ellipse ellipse) {
            ListID = ShapesVM.NodeList[new Point(ellipse.Margin.Left + ShapesVM.EllipseRadius, ellipse.Margin.Top + ShapesVM.EllipseRadius)];
        }
        public static void EndNodeMoving() {
        }
        #endregion
        #region NodeWorking
        private static void AddNode(Point point, ShapesVM.Destination destination) {
            newNode = true;
            foreach (Point Node in ShapesVM.NodeList.Keys) {
                if (Node == point) {
                    ShapesVM.NodeList[point].Add((currentLineInfo.Id, destination));
                    newNode = false;
                    break;
                }
            }
            if (newNode) {
                ShapesVM.NodeList.Add(point, new List<(int, ShapesVM.Destination)>() { (currentLineInfo.Id, destination) });
            }
        }
        public static void NodeCheck(Point position) {
            for (int i = 0; i < ShapesVM.ShapesInfoList.Count; i++) {
                if (ShapesVM.ShapesInfoList[i] is EllipseInfo) {
                    Point tempPoint = new Point(((EllipseInfo)ShapesVM.ShapesInfoList[i]).Margin.Left + ShapesVM.EllipseRadius, ((EllipseInfo)ShapesVM.ShapesInfoList[i]).Margin.Top + ShapesVM.EllipseRadius);
                    if (endDrawing && tempPoint.Equals(currentLineInfo.StartPoint)) {
                        continue;
                    }
                    double XIndent = tempPoint.X - position.X;
                    double YIndent = tempPoint.Y - position.Y;
                    if (XIndent < 10 && XIndent > -10
                        && YIndent < 10 && YIndent > -10) {
                        ((EllipseInfo)ShapesVM.ShapesInfoList[i]).Brush = Brushes.Gold;
                        node = true;
                        NodePosition = tempPoint;
                        return;

                    }
                    else {
                        ((EllipseInfo)ShapesVM.ShapesInfoList[i]).Brush = Brushes.Transparent;
                    }

                }
            }
            foreach (Point point in ShapesVM.NodeList.Keys) {


            }
            node = false;
        }
        #endregion
    }
}
