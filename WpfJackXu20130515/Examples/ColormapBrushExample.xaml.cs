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
    /// Lógica interna para ColormapBrushExample.xaml
    /// </summary>
    public partial class ColormapBrushExample : Window {
        public ColormapBrushExample() {
            InitializeComponent();
            FillRectangles();
            AddMathFunction();
        }

        private void FillRectangles() {
            // Fill rect1 with "Spring" colormap:
            Library.ColormapBrush brush = new Library.ColormapBrush();
            rect1.Fill = brush.Spring();

            // Fill rect2 with "Summer" colormap:
            brush = new Library.ColormapBrush();
            rect2.Fill = brush.Summer();

            // Fill rect3 with "Autumn" colormap:
            brush = new Library.ColormapBrush();
            rect3.Fill = brush.Autumn();

            // Fill rect4 with "Winter" colormap:
            brush = new Library.ColormapBrush();
            rect4.Fill = brush.Winter();

            // Fill rect5 with "Jet" colormap:
            brush = new Library.ColormapBrush();
            rect5.Fill = brush.Jet();

            // Fill rect6 with "Gray" colormap:
            brush = new Library.ColormapBrush();
            rect6.Fill = brush.Gray();

            // Fill rect7 with "Hot" colormap:
            brush = new Library.ColormapBrush();
            rect7.Fill = brush.Hot();

            // Fill rect8 with "Cool" colormap:
            brush = new Library.ColormapBrush();
            rect8.Fill = brush.Cool();
        }

        private void AddMathFunction() {
            // Create a cosine curve:
            Library.ColormapBrush brush1 = new Library.ColormapBrush();
            brush1.StartPoint = new Point(0, 0);
            brush1.EndPoint = new Point(0, 1);
            Polyline line1 = new Polyline();
            for (int i = 0; i < 250; i++) {
                double x = i;
                double y = 70 + 50 * Math.Sin(x / 4.0 / Math.PI);
                line1.Points.Add(new Point(x, y));
            }
            line1.Stroke = brush1.Spring();
            line1.StrokeThickness = 5;
            Canvas.SetLeft(line1, 20);
            canvas1.Children.Add(line1);

            // Create a cosine curve:
            brush1 = new Library.ColormapBrush();
            brush1.StartPoint = new Point(0, 1);
            brush1.EndPoint = new Point(0, 0);
            line1 = new Polyline();
            for (int i = 0; i < 250; i++) {
                double x = i;
                double y = 70 + 50 * Math.Cos(x / 4.0 / Math.PI);
                line1.Points.Add(new Point(x, y));
            }
            line1.Stroke = brush1.Jet();
            line1.StrokeThickness = 5;
            Canvas.SetLeft(line1, 20);
            canvas1.Children.Add(line1);
        }
    }
}
