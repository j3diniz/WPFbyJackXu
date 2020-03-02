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
    /// Interaction logic for FirstWPFProgram.xaml
    /// </summary>
    public partial class FirstWPFProgram : Window {
        public FirstWPFProgram() {
            InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e) {
            textBlock.Text = textBox.Text;

        }

        private void btnChangeColor_Click(object sender, RoutedEventArgs e) {
            if (textBlock.Foreground == Brushes.Black) {
                textBlock.Foreground = Brushes.Red;
            } else {
                textBlock.Foreground = Brushes.Black;
            }
        }

        private void btnChangeSize_Click(object sender, RoutedEventArgs e) {
            if (textBlock.FontSize == 11) {
                textBlock.FontSize = 24;
            } else {
                textBlock.FontSize = 11;
            }
        }


    }
}
