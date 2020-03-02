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
    /// Interaction logic for CodeOnly.xaml
    /// </summary>
    public partial class CodeOnly : Window {

        private TextBlock textBlock;
        private TextBox textBox;

        public CodeOnly() {
            // InitializeComponent();
            Inicialization();
        }

        private void Inicialization() { 
            // Configure the Window:
            this.Height = 300;
            this.Width = 300;
            this.Title = "Code only example";

            // Create Grid and StackPanel and add them to Window:
            Grid grid = new Grid();
            StackPanel stackPanel = new StackPanel();
            grid.Children.Add(stackPanel);
            this.AddChild(grid);

            // Add a TextBlock to StackPanel:
            textBlock = new TextBlock();
            textBlock.Margin = new Thickness(5);
            textBlock.Height = 30;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.Text = "Hello WPF!";
            stackPanel.Children.Add(textBlock);

            // Add a TextBox to StackPanel:
            textBox = new TextBox();
            textBox.Margin = new Thickness(5);
            textBox.Width = 200;
            textBox.TextAlignment = TextAlignment.Center;
            textBox.TextChanged += OnTextChanged;
            stackPanel.Children.Add(textBox);

            // Add Button to StackPanel used to change text color:
            Button btnColor = new Button();
            btnColor.Margin = new Thickness(5);
            btnColor.Width = 200;
            btnColor.Content = "Change Text Color";
            btnColor.Click += btnChangeColor_Click;
            stackPanel.Children.Add(btnColor);

            // Add Button to StackPanel used to change text font size:
            Button btnSize = new Button();
            btnSize.Margin = new Thickness(5);
            btnSize.Width = 200;
            btnSize.Content = "Change Text Color";
            btnSize.Click += btnChangeSize_Click;
            stackPanel.Children.Add(btnSize);
        }

        void btnChangeSize_Click(object sender, RoutedEventArgs e) {
            //throw new NotImplementedException();
            if (textBox.FontSize == 11) {
                textBox.FontSize = 24;
            } else {
                textBox.FontSize = 11;
            }
        }

        void btnChangeColor_Click(object sender, RoutedEventArgs e) {
            //throw new NotImplementedException();
            if (textBox.Foreground == Brushes.Black) {
                textBox.Foreground = Brushes.Red;
            } else {
                textBox.Foreground = Brushes.Black;
            }
        }

        void OnTextChanged(object sender, TextChangedEventArgs e) {
            //throw new NotImplementedException();
            textBlock.Text = textBox.Text;
        }


    }
}
