﻿using System;
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
using Microsoft.Samples.CustomControls;

namespace WpfJackXu20130515.Examples {
    /// <summary>
    /// Interaction logic for SolidColorBrushExample.xaml
    /// </summary>
    public partial class SolidColorBrushExample : Window {
        public SolidColorBrushExample() {
            InitializeComponent();

            SolidColorBrush brush = new SolidColorBrush();

            // Predefined brush in Brushes Class:
            brush = Brushes.Red;
            rect1.Fill = brush;

            // From predefined color name in the Colors class:
            brush = new SolidColorBrush(Colors.Green);
            rect2.Fill = brush;

            // From sRGB values in the Color strutcure:
            brush = new SolidColorBrush(Color.FromArgb(100, 0, 0, 255));
            rect3.Fill = brush;

            // From ScRGB values in the Color structure:
            brush = new SolidColorBrush(Color.FromScRgb(0.5f, 0.7f, 0.0f, 0.5f));
            rect4.Fill = brush;

            // From Hex string using ColorCoverter:
            brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CBFFFFAA"));
            rect5.Fill = brush;
        }

        // From ColorPickerDialog:
        private void ChangeColor_Click(object sender, RoutedEventArgs e) {
            ColorPickerDialog cPicker = new ColorPickerDialog();
            cPicker.StartingColor = Colors.LightBlue;
            cPicker.Owner = this;
            bool? dialogResult = cPicker.ShowDialog();
            if (dialogResult != null && (bool)dialogResult == true) {
                rect6.Fill = new SolidColorBrush(cPicker.SelectedColor);
            }
        }
    }
}
