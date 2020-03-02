using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfJackXu20130515.Examples {
    /// <summary>
    /// Interaction logic for Interactive2DDrawing.xaml
    /// </summary>
    public partial class Interactive2DDrawing : Window {

        private List<Path> paths = new List<Path>();
        private Point startPoint = new Point();
        private Shape rubberBand = null;
        Point currentPoint = new Point();
        private bool isDragging = false;
        private bool isDown = false;
        private Path originalElement = new Path();
        private Path movingElement = new Path();
        private Path path1 = new Path();
        private Path path2 = new Path();
        private SolidColorBrush fillColor = new SolidColorBrush();
        private SolidColorBrush borderColor = new SolidColorBrush();
        private SolidColorBrush selectFillColor = new SolidColorBrush();
        private SolidColorBrush selectBorderColor = new SolidColorBrush();

        public Interactive2DDrawing() {
            InitializeComponent();
            fillColor.Color = Colors.LightGray;
            fillColor.Opacity = 0.5;
            borderColor.Color = Colors.Gray;
            selectFillColor.Color = Colors.LightCoral;
            selectFillColor.Opacity = 0.5;
            selectBorderColor.Color = Colors.Red;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (!canvas1.IsMouseCaptured) {
                startPoint = e.GetPosition(canvas1);
                canvas1.CaptureMouse();

                if (rbCombine.IsChecked == true) {
                    SetCombineShapes(e);
                } else if (rbSelect.IsChecked == true) {
                    if(canvas1 == e.Source)
                        return;
                    isDown = true;
                    originalElement = (Path)e.Source;
                    e.Handled = true;
                } else if (rbDelete.IsChecked == true) {
                    originalElement = (Path)e.Source;
                    DeleteShape(originalElement);
                }
            }
        }

        private void DeleteShape(Path path) {
            path.Stroke = selectBorderColor;
            string msg = "Do you really want to delete this shape?";
            string title = "Delete Shape?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(msg,title,buttons,icon);
            if (result == MessageBoxResult.Yes) {
                canvas1.Children.Remove(path);
            } else {
                path.Stroke = borderColor;
                return;
            }
        }

        private void SetCombineShapes(MouseButtonEventArgs e) {
            if (path1.Name != "path1Selected") {
                path1 = (Path)e.Source;
                path1.Cursor = Cursors.Hand;
                path1.Stroke = selectBorderColor;
                path1.Name = "path1Selected";
            } else {
                if (path2 != null) {
                    path2.Stroke = borderColor;
                    path2.Cursor = Cursors.Arrow;
                }
                path2 = (Path)e.Source;
                path2.Cursor = Cursors.Hand;
                path2.Stroke = selectBorderColor;

                ContextMenu cm = new ContextMenu();
                path2.ContextMenu = cm;
                MenuItem mi = new MenuItem();
                mi.Header = "Union";
                mi.Click += new RoutedEventHandler(Union_Click);
                cm.Items.Add(mi);
                mi = new MenuItem();
                mi.Header = "Xor";
                mi.Click += new RoutedEventHandler(Xor_Click);
                cm.Items.Add(mi);
                mi = new MenuItem();
                mi.Header = "Intersect";
                mi.Click += new RoutedEventHandler(Intersect_Click);
                cm.Items.Add(mi);
                mi = new MenuItem();
                mi.Header = "Exclude";
                mi.Click += new RoutedEventHandler(Exclude_Click);
                cm.Items.Add(mi);
            }
        }

        private void Union_Click(object sender, RoutedEventArgs e) {
            CombineShapes(path1, path2, "Union");
            path1.Name = "";
        }

        private void Xor_Click(object sender, RoutedEventArgs e) {
            CombineShapes(path1, path2, "Xor");
            path1.Name = "";
        }

        private void Intersect_Click(object sender, RoutedEventArgs e) {
            CombineShapes(path1, path2, "Intersect");
            path1.Name = "";      
        }

        private void Exclude_Click(object sender, RoutedEventArgs e) {
            CombineShapes(path1, path2, "Exclude");
            path1.Name = "";
        }

        private void CombineShapes(Path p1, Path p2, string s) {
            Path myPath = new Path();
            myPath.Fill = fillColor;
            myPath.Stroke = borderColor;
            CombinedGeometry cg = new CombinedGeometry();

            if (s == "Union") {
                cg.GeometryCombineMode = GeometryCombineMode.Union;
            } else if (s == "Xor") {
                cg.GeometryCombineMode = GeometryCombineMode.Xor;
            } else if (s == "Intersect") {
                cg.GeometryCombineMode = GeometryCombineMode.Intersect;
            } else if (s == "Exclude") {
                cg.GeometryCombineMode = GeometryCombineMode.Exclude;
            }
            cg.Geometry1 = p1.Data;
            cg.Geometry2 = p2.Data;
            myPath.Data = cg;
            paths.Add(myPath);
            canvas1.Children.Add(paths[paths.Count - 1]);
            canvas1.Children.Remove(p1);
            canvas1.Children.Remove(p2);
        }
        
        /*void mi_Click(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }*/

        private void OnMouseMove(object sender, MouseEventArgs e) {
            if (canvas1.IsMouseCaptured) {
                currentPoint = e.GetPosition(canvas1);
                if (rubberBand == null) {
                    rubberBand = new Rectangle();
                    rubberBand.Stroke = Brushes.LightCoral;
                    rubberBand.StrokeDashArray = new DoubleCollection(new double[] { 4, 2 });
                    if (rbSquare.IsChecked == true ||
                        rbRectangle.IsChecked == true||
                        rbCircle.IsChecked ==true||
                        rbEllipse.IsChecked ==true) {
                            canvas1.Children.Add(rubberBand);
                    }
                }
                double width = Math.Abs(startPoint.X - currentPoint.X);
                double height = Math.Abs(startPoint.Y - currentPoint.Y);
                double left = Math.Min(startPoint.X, currentPoint.X);
                double top = Math.Min(startPoint.Y, currentPoint.Y);

                rubberBand.Width = width;
                rubberBand.Height = height;
                Canvas.SetLeft(rubberBand, left);
                Canvas.SetTop(rubberBand, top);

                if (rbSelect.IsChecked == true) {
                    if (isDown) {
                        if (!isDragging && Math.Abs(currentPoint.X - startPoint.X)>
                            SystemParameters.MinimumHorizontalDragDistance &&
                            Math.Abs(currentPoint.Y - startPoint.Y) >
                            SystemParameters.MinimumVerticalDragDistance){
                                DragStarting();
                        }
                        if (isDragging) {
                            DragMoving();
                        }
                    }
                }
            }
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            if (rbSquare.IsChecked == true) {
                AddSquare(startPoint, currentPoint);
            } else if (rbRectangle.IsChecked == true) {
                AddRectangle(startPoint, currentPoint);
            } else if (rbCircle.IsChecked == true) {
                AddCircle(startPoint, currentPoint);
            } else if (rbEllipse.IsChecked == true) {
                AddEllipse(startPoint, currentPoint);
            }

            if (rubberBand != null) {
                canvas1.Children.Remove(rubberBand);
                rubberBand = null;
                canvas1.ReleaseMouseCapture();
            }
            if (rbSelect.IsChecked == true) {
                if (isDown) {
                    DragFinishing(false);
                    e.Handled = true;
                }
            }
        }

        private void AddRectangle(Point pt1, Point pt2) {
            Path path = new Path();
            path.Fill = fillColor;
            path.Stroke = borderColor;
            RectangleGeometry rg = new RectangleGeometry();
            double width = Math.Abs(pt1.X - pt2.X);
            double height = Math.Abs(pt1.Y - pt2.Y);
            double left = Math.Min(pt1.X, pt2.X);
            double top = Math.Min(pt1.Y, pt2.Y);
            rg.Rect = new Rect(left, top, width, height);
            path.Data = rg;
            paths.Add(path);
            canvas1.Children.Add(paths[paths.Count - 1]);
        }

        private void AddSquare(Point pt1, Point pt2) {
            Path path = new Path();
            path.Fill = fillColor;
            path.Stroke = borderColor;
            RectangleGeometry rg = new RectangleGeometry();
            double width = Math.Abs(pt1.X - pt2.X);
            double height = Math.Abs(pt1.Y - pt2.Y);
            double left = Math.Min(pt1.X, pt2.X);
            double top = Math.Min(pt1.Y, pt2.Y);
            double side = width;
            if (width>height) {
                side = height;
            }
            rg.Rect = new Rect(left, top, width, height);
            path.Data = rg;
            paths.Add(path);
            canvas1.Children.Add(paths[paths.Count - 1]);
        }

        private void AddCircle(Point pt1, Point pt2) {
            Path path = new Path();
            path.Fill = fillColor;
            path.Stroke = borderColor;
            EllipseGeometry eg = new EllipseGeometry();
            double width = Math.Abs(pt1.X - pt2.X);
            double height = Math.Abs(pt1.Y - pt2.Y);
            double left = Math.Min(pt1.X, pt2.X);
            double top = Math.Min(pt1.Y, pt2.Y);
            double side = width;
            if (width > height) {
                side = height;
            }
            eg.Center = new Point(left + side / 2, top + side / 2);
            eg.RadiusX = side / 2;
            eg.RadiusY = side / 2;
            path.Data = eg;
            paths.Add(path);
            canvas1.Children.Add(paths[paths.Count - 1]);
        }

        private void AddEllipse(Point pt1, Point pt2) {
            Path path = new Path();
            path.Fill = fillColor;
            path.Stroke = borderColor;
            EllipseGeometry eg = new EllipseGeometry();
            double width = Math.Abs(pt1.X - pt2.X);
            double height = Math.Abs(pt1.Y - pt2.Y);
            double left = Math.Min(pt1.X, pt2.X);
            double top = Math.Min(pt1.Y, pt2.Y);
            eg.Center = new Point(left + width / 2, top + height / 2);
            eg.RadiusX = width / 2;
            eg.RadiusY = height / 2;
            path.Data = eg;
            paths.Add(path);
            canvas1.Children.Add(paths[paths.Count - 1]);
        }

        private void DragStarting() {
            isDragging = true;
            movingElement = new Path();
            movingElement.Data = originalElement.Data;
            movingElement.Fill = selectFillColor;
            movingElement.Stroke = selectBorderColor;
            canvas1.Children.Add(movingElement);
        }

        private void DragMoving() {
            currentPoint = Mouse.GetPosition(canvas1);
            TranslateTransform tt = new TranslateTransform();
            tt.X = currentPoint.X - startPoint.X;
            tt.Y = currentPoint.Y - startPoint.Y;
            movingElement.RenderTransform = tt;
        }

        private void DragFinishing(bool cancel) {
            Mouse.Capture(null);
            if (isDragging) {
                if (!cancel) {
                    currentPoint = Mouse.GetPosition(canvas1);
                    TranslateTransform tt0 = new TranslateTransform();
                    TranslateTransform tt = new TranslateTransform();
                    tt.X = currentPoint.X - startPoint.X;
                    tt.Y = currentPoint.Y - startPoint.Y;
                    Geometry geometry = (RectangleGeometry)new RectangleGeometry();

                    string s = originalElement.Data.ToString();
                    if (s == "System.Windows.Media.EllipseGeometry") {
                        geometry = (EllipseGeometry)originalElement.Data;
                    } else if (s == "System.Windows.Media.RectangleGeometry") {
                        geometry = (RectangleGeometry)originalElement.Data;
                    } else if (s == "System.Windows.Media.CombinedGeometry") {
                        geometry = (CombinedGeometry)originalElement.Data;
                    }
                    if (geometry.Transform.ToString() != "Identity") {
                        tt0 = (TranslateTransform)geometry.Transform;
                        tt.X += tt0.X;
                        tt.Y += tt0.Y;
                    }

                    geometry.Transform = tt;
                    canvas1.Children.Remove(originalElement);
                    originalElement = new Path();
                    originalElement.Fill = fillColor;
                    originalElement.Stroke = borderColor;
                    originalElement.Data = geometry;
                    canvas1.Children.Add(originalElement);
                }
                canvas1.Children.Remove(movingElement);
                movingElement = null;
            }
            isDragging = false;
            isDown = false;
        }

    }
}
