using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfJackXu20130515.Library {
    class ColormapBrush {
        private double opacity = 1;
        private Point startPoint = new Point(0, 0);
        private Point endPoint = new Point(1, 0);
        private LinearGradientBrush brush = new LinearGradientBrush();

        public double Opacity {
            get { return opacity;}
            set { opacity = value;}
        }

        public Point StartPoint {
            get { return startPoint;}
            set { startPoint = value;}
        }

        public Point EndPoint {
            get { return endPoint;}
            set { endPoint = value;}
        }

        public LinearGradientBrush Spring() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 255), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 0), 1));
            brush.StartPoint = StartPoint;
            brush.EndPoint = EndPoint;
            brush.Opacity = opacity;
            return brush;
        }

        public LinearGradientBrush Summer() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 128, 90), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 90), 1));
            brush.StartPoint = StartPoint;
            brush.EndPoint = EndPoint;
            brush.Opacity = opacity;
            return brush;
        }

        public LinearGradientBrush Autumn() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 0), 1));
            brush.StartPoint = StartPoint;
            brush.EndPoint = EndPoint;
            brush.Opacity = opacity;
            return brush;
        }

        public LinearGradientBrush Winter() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 128), 1));
            brush.StartPoint = StartPoint;
            brush.EndPoint = EndPoint;
            brush.Opacity = opacity;
            return brush;
        }

        public LinearGradientBrush Hot() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(85, 0, 0), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0.25));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 85, 0), 0.375));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 0), 0.625));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 128), 0.75));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 255), 1));
            brush.StartPoint = StartPoint;
            brush.EndPoint = EndPoint;
            brush.Opacity = opacity;
            return brush;
        }

        public LinearGradientBrush Cool() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 255), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 255), 1));
            brush.StartPoint = StartPoint;
            brush.EndPoint = EndPoint;
            brush.Opacity = opacity;
            return brush;
        }

        public LinearGradientBrush Gray() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 0), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 255), 1));
            brush.StartPoint = StartPoint;
            brush.EndPoint = EndPoint;
            brush.Opacity = opacity;
            return brush;
        }

        public LinearGradientBrush Jet() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 128, 255), 0.143));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 255), 0.286));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(128, 255, 128), 0.429));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 0), 0.571));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0.857));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(128, 0, 0), 1));
            brush.StartPoint = StartPoint;
            brush.EndPoint = EndPoint;
            brush.Opacity = opacity;
            return brush;
        }

    }
}
