using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
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
            ShapesVM.ShapesInfoList.Add(new EllipseInfo() { radius = ShapesVM.radius });
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
        }
        private static void EndDrawing(Point point) {
            AddNode(point, ShapesVM.Destination.EndPoint);
            currentLineInfo.EndPoint = point;
            currentLineInfo.Brush = Brushes.Black;
            ShapesVM.ShapesInfoList[currentLineInfo.Id] = new LineInfo(currentLineInfo);
        }
        #endregion
        #region LineDelete
        public static void LineDelete() {
            if (endLineMoving) {
                endLineMoving = false;
                ShapesVM.ShapesInfoList[currentId] = null;
                if (ShapesVM.NodeList[currentLineInfo.StartPoint].Count > 1) {
                    ShapesVM.NodeList[currentLineInfo.StartPoint].Remove((currentId, ShapesVM.Destination.StartPoint));
                }
                else {
                    ShapesVM.NodeList.Remove(currentLineInfo.StartPoint);
                }
                if (ShapesVM.NodeList[currentLineInfo.EndPoint].Count > 1) {
                    ShapesVM.NodeList[currentLineInfo.EndPoint].Remove((currentId, ShapesVM.Destination.EndPoint));
                }
                else {
                    ShapesVM.NodeList.Remove(currentLineInfo.EndPoint);
                }
            }
        }
        #endregion
        #region MoveButton
        public static Line currentLine;
        public static bool endLineMoving;
        public static bool pressed;
        public static Point startPosition;
        public static Point startDiff;
        public static Point endDiff;
        public static int currentId;

        private static bool IsMoveChecked {
            get {
                return MouseBehaviour.IsMoveChecked;
            }
        }
        public static void LineChoosing(object sender, MouseButtonState buttonState) {
            if (!IsMoveChecked) {
                return;
            }
            if (endNodeMoving) {
                EndNodeMoving();
                return;
            }
            if (buttonState == MouseButtonState.Pressed) {
                pressed = true;
                startPosition = MouseBehaviour.position;
                currentLine = (Line)sender;
            }
            else {
                pressed = false;
                double XIndent = MouseBehaviour.position.X - startPosition.X;
                double YIndent = MouseBehaviour.position.Y - startPosition.Y;
                if (XIndent < 10 && XIndent > -10
                    && YIndent < 10 && YIndent > -10 && !endLineMoving) {
                    for (int i = 1; i < ShapesVM.ShapesInfoList.Count; i++) {
                        if (i == Convert.ToInt32(((Line)sender).Uid)) {
                            continue;
                        }
                        ShapesVM.ShapesInfoList[i] = new LineInfo(((LineInfo)ShapesVM.ShapesInfoList[i]).StartPoint, ((LineInfo)ShapesVM.ShapesInfoList[i]).EndPoint, Brushes.Black, ((LineInfo)ShapesVM.ShapesInfoList[i]).Id);
                    }
                    ShapesVM.ShapesInfoList[Convert.ToInt32(((Line)sender).Uid)]
                    = new LineInfo(
                    ((LineInfo)ShapesVM.ShapesInfoList[Convert.ToInt32(((Line)sender).Uid)]).StartPoint,
                    ((LineInfo)ShapesVM.ShapesInfoList[Convert.ToInt32(((Line)sender).Uid)]).EndPoint,
                    Brushes.Aqua,
                    Convert.ToInt32(((Line)sender).Uid));
                    return;
                }
                if (endLineMoving) {
                    endLineMoving = false;
                    EndLineMoving();
                    return;
                }
            }
        }
        public static void LineMoving(object sender) {

            if (!endLineMoving) {
                Line line = (Line)sender;
                startDiff = new Point(position.X - line.X1, position.Y - line.Y1);
                endDiff = new Point(position.X - line.X2, position.Y - line.Y2);
                StartLineMoving(line);
                endLineMoving = true;
            }
        }
        public static void StartLineMoving(Line line) {
            currentLineInfo = new LineInfo(new Point(line.X1, line.Y1), new Point(line.X2, line.Y2), Brushes.Green, false);
            currentId = Convert.ToInt32(line.Uid);
        }
        public static void EndLineMoving() {
            ShapesVM.ShapesInfoList[currentId]
                = new LineInfo(
                    new Point(position.X - startDiff.X, position.Y - startDiff.Y),
                    new Point(position.X - endDiff.X, position.Y - endDiff.Y),
                    Brushes.Black,
                    currentId);
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
        public static Ellipse currentEllipse;
        public static void NodeMoving(object sender) {
            if (!IsMoveChecked || endLineMoving) {
                return;
            }
            else if (!endNodeMoving) {
                Ellipse tempEllipse = sender as Ellipse;
                currentEllipse = new Ellipse() { Margin = tempEllipse.Margin, Width = tempEllipse.Width, Height = tempEllipse.Height, Fill = tempEllipse.Fill };
                StartNodeMoving();
                endNodeMoving = true;
            }
        }
        public static void StartNodeMoving() {
            ListID = ShapesVM.NodeList[new Point(currentEllipse.Margin.Left + ShapesVM.radius / 2, currentEllipse.Margin.Top + ShapesVM.radius / 2)];
        }
        public static void EndNodeMoving() {
            ShapesVM.NodeList.Add(new Point(MouseBehaviour.position.X, MouseBehaviour.position.Y), ShapesVM.NodeList[new Point(currentEllipse.Margin.Left + ShapesVM.radius / 2, currentEllipse.Margin.Top + ShapesVM.radius / 2)]);
            foreach (var ts in ShapesVM.NodeList[new Point(MouseBehaviour.position.X, MouseBehaviour.position.Y)]) {
                ShapesVM.ShapesInfoList[ts.Item1] = new LineInfo(((LineInfo)ShapesVM.ShapesInfoList[ts.Item1]).StartPoint, ((LineInfo)ShapesVM.ShapesInfoList[ts.Item1]).EndPoint, Brushes.Black, ts.Item1);
            }
            ShapesVM.NodeList.Remove(new Point(currentEllipse.Margin.Left + ShapesVM.radius / 2, currentEllipse.Margin.Top + ShapesVM.radius / 2));
            endNodeMoving = false;
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
            foreach (Point point in ShapesVM.NodeList.Keys) {
                if (endDrawing && point.Equals(currentLineInfo.StartPoint)) {
                    continue;
                }
                double XIndent = point.X - position.X;
                double YIndent = point.Y - position.Y;
                if (XIndent < 10 && XIndent > -10
                    && YIndent < 10 && YIndent > -10) {
                    ShapesVM.ShapesInfoList[0] = new EllipseInfo() {
                        radius = ShapesVM.radius,
                        margin = new Thickness(point.X - 10, point.Y - 10, 0, 0),
                        brush = Brushes.Gold
                    };
                    node = true;
                    NodePosition = point;
                    return;
                }
                else {
                    ShapesVM.ShapesInfoList[0] = new EllipseInfo() {
                        radius = ShapesVM.radius,
                        brush = Brushes.Transparent
                    };
                }
            }
            node = false;
        }
        #endregion
    }
}
