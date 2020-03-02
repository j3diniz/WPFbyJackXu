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
    /// Lógica interna para RadialColormapBrush.xaml
    /// </summary>
    public partial class RadialColormapBrush : Window {
        public RadialColormapBrush() {
            InitializeComponent();
            FillEllipses();
        }

        private void FillEllipses() {

            // Fill ellipse1 with "Spring" colormap:
            Library.RadialColormapBrush brush = new Library.RadialColormapBrush();
            ellipse1.Fill = brush.Spring();

            // Fill ellipse2 with "Summer" colormap:
            brush = new Library.RadialColormapBrush();
            ellipse2.Fill = brush.Summer();

            // Fill ellipse3 with "Autumn" colormap:
            brush = new Library.RadialColormapBrush();
            ellipse3.Fill = brush.Autumn();

            // Fill ellipse4 with "Winter" colormap:
            brush = new Library.RadialColormapBrush();
            ellipse4.Fill = brush.Winter();

            // Fill ellipse5 with "Jet" colormap:
            brush = new Library.RadialColormapBrush();
            ellipse5.Fill = brush.Jet();

            // Fill ellipse6 with "Gray" colormap:
            brush = new Library.RadialColormapBrush();
            ellipse6.Fill = brush.Gray();

            // Fill ellipse7 with "Hot" colormap:
            brush = new Library.RadialColormapBrush();
            ellipse7.Fill = brush.Hot();

            // Fill ellipse8 with "Cool" colormap:
            brush = new Library.RadialColormapBrush();
            ellipse8.Fill = brush.Cool();

        }

    }
}
