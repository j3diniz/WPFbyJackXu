using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfJackXu20130515.Library {
    public class RadialColormapBrush {
        private Point center = new Point(0.5, 0.5);
        private Point gradientOrigin = new Point(0.5, 0.5);
        private double radiusX = 0.5;
        private double radiusY = 0.5;
        private double opacity = 1;
        private RadialGradientBrush brush = new RadialGradientBrush();

        public Point Center {
            get { return center; }
            set { center = value; }
        }

        public Point GradientOrigin {
            get { return gradientOrigin; }
            set { gradientOrigin = value; }
        }

        public double RadiusX {
            get { return radiusX; }
            set { radiusX = value; }
        }

        public double RadiusY {
            get { return radiusY; }
            set { radiusY = value; }
        }

        public double Opacity {
            get { return opacity; }
            set { opacity = value; }
        }

        public RadialGradientBrush Spring() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 255), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 0), 1));
            brush.Center = Center;
            brush.GradientOrigin = GradientOrigin;
            brush.RadiusX = RadiusX;
            brush.RadiusY = RadiusY;
            brush.Opacity = Opacity;
            return brush;
        }

        public RadialGradientBrush Summer() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 128, 90), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 90), 1));
            brush.Center = Center;
            brush.GradientOrigin = GradientOrigin;
            brush.RadiusX = RadiusX;
            brush.RadiusY = RadiusY;
            brush.Opacity = Opacity;
            return brush;
        }

        public RadialGradientBrush Autumn() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 0), 1));
            brush.Center = Center;
            brush.GradientOrigin = GradientOrigin;
            brush.RadiusX = RadiusX;
            brush.RadiusY = RadiusY;
            brush.Opacity = Opacity;
            return brush;
        }

        public RadialGradientBrush Winter() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 128), 1));
            brush.Center = Center;
            brush.GradientOrigin = GradientOrigin;
            brush.RadiusX = RadiusX;
            brush.RadiusY = RadiusY;
            brush.Opacity = Opacity;
            return brush;
        }

        public RadialGradientBrush Hot() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(85, 0, 0), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0.25));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 85, 0), 0.375));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 0), 0.625));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 128), 0.75));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 255), 1));
            brush.Center = Center;
            brush.GradientOrigin = GradientOrigin;
            brush.RadiusX = RadiusX;
            brush.RadiusY = RadiusY;
            brush.Opacity = Opacity;
            return brush;
        }

        public RadialGradientBrush Cool() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 255), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 255), 1));
            brush.Center = Center;
            brush.GradientOrigin = GradientOrigin;
            brush.RadiusX = RadiusX;
            brush.RadiusY = RadiusY;
            brush.Opacity = Opacity;
            return brush;
        }

        public RadialGradientBrush Gray() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 0), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 255), 1));
            brush.Center = Center;
            brush.GradientOrigin = GradientOrigin;
            brush.RadiusX = RadiusX;
            brush.RadiusY = RadiusY;
            brush.Opacity = Opacity;
            return brush;
        }

        public RadialGradientBrush Jet() {
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 0, 255), 0));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 128, 255), 0.143));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(0, 255, 255), 0.286));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(128, 255, 128), 0.429));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 0), 0.571));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 128, 0), 0.714));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(255, 0, 0), 0.857));
            brush.GradientStops.Add(new GradientStop(Color.FromRgb(128, 0, 0), 1));
            brush.Center = Center;
            brush.GradientOrigin = GradientOrigin;
            brush.RadiusX = RadiusX;
            brush.RadiusY = RadiusY;
            brush.Opacity = Opacity;
            return brush;
        }

    }
}
