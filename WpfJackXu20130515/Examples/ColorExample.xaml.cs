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
using System.Reflection;

namespace WpfJackXu20130515.Examples {
    /// <summary>
    /// Interaction logic for ColorExample.xaml
    /// </summary>
    public partial class ColorExample : Window {

        private Color color;
        SolidColorBrush colorBrush = new SolidColorBrush();

        public ColorExample() {
            InitializeComponent();

            Type colorsType = typeof(Colors);
            foreach (PropertyInfo property in colorsType.GetProperties()) {
                listBox1.Items.Add(property.Name);
                color = Colors.AliceBlue;
                listBox1.SelectedIndex = 0;
                ColorInfo();
            }
        }

        private void listBox1SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string colorString = listBox1.SelectedItem.ToString();
            color = (Color)ColorConverter.ConvertFromString(colorString);
            float opacity = Convert.ToSingle(textBox.Text);
            if (opacity > 1.0f) {
                opacity = 1.0f;
            } else if (opacity < 0.0f) {
                opacity = 0.0f;
            }
            color.ScA = opacity;
            ColorInfo();
        }

        private void ColorInfo() {
            rect1.Fill = new SolidColorBrush(color);

            /// sRGB color info:
            tbAlpha.Text = "Alpha = " + color.A.ToString();
            tbRed.Text = "Red = " + color.R.ToString();
            tbGreen.Text = "Green = " + color.G.ToString();
            tbBlue.Text = "Blue = " + color.B.ToString();
            string rgbHex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
            tbRGB.Text = "ARGB = #" + rgbHex;

            /// ScRGB color info:
            tbScA.Text = "ScA = " + color.ScA.ToString();
            tbScR.Text = "ScR = " + color.ScR.ToString();
            tbScG.Text = "ScG = " + color.ScG.ToString();
            tbScB.Text = "ScB = " + color.ScB.ToString();
        }

    }
}
