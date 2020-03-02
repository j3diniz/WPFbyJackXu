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

namespace WpfJackXu20130515.Forms {
    /// <summary>
    /// Interaction logic for Tester.xaml
    /// </summary>
    public partial class Tester : Window {
        public Tester() {
            InitializeComponent();

            for (int i = 0; i < 70; i++) {
                double x = i * Math.PI;
                double y = 40 + 30 * Math.Sin(x / 10);
                polyline1.Points.Add(new Point(x, y));
            }
        }
    }
}
