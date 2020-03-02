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

namespace WpfJackXu20130515.Examples
{
    /// <summary>
    /// Interaction logic for HitTestExample.xaml
    /// </summary>
    public partial class HitTestExample : Window{

        private List<Rectangle> hitList = new List<Rectangle>();
        private EllipseGeometry hitArea = new EllipseGeometry();

        public HitTestExample(){
            InitializeComponent();
            Initialize();
        }

        private void Initialize() {
            foreach (Rectangle rect in canvas1.Children){
                rect.Fill = Brushes.LightBlue;
            }
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e){
            // Initialization:
            Initialize();

            // Get mouse point:
            Point pt = e.GetPosition(canvas1);

            // Define hit-testing area:
            hitArea = new EllipseGeometry(pt, 1.0, 1.0);
            hitList.Clear();

            // Call HitTest method:
            VisualTreeHelper.HitTest(canvas1, null,
                new HitTestResultCallback(HitTestCallback),
                new GeometryHitTestParameters(hitArea));

            if (hitList.Count > 0){
                foreach (Rectangle rect in hitList){
                    // Change rectangle fill color if it is hit:
                    rect.Fill = Brushes.LightCoral;
                }
                MessageBox.Show("You hit " + hitList.Count.ToString() + " retangles.");
            }
        }

        public HitTestResultBehavior HitTestCallback(HitTestResult result) {
            // Retrive the results of the hit test.
            IntersectionDetail intersectionalDetail = ((GeometryHitTestResult)result).IntersectionDetail;
            switch (intersectionalDetail) {
                //case IntersectionDetail.Empty:
                    //break;
                case IntersectionDetail.FullyContains:
                    //break;
                    // Add the hit test result to the list:
                    hitList.Add((Rectangle)result.VisualHit);
                    return HitTestResultBehavior.Continue;
                case IntersectionDetail.FullyInside:
                    //break;
                    // Set the behavior to return visuals at all z-order levels:
                    return HitTestResultBehavior.Continue;
                case IntersectionDetail.Intersects:
                    //break;
                    // Set the behavior to return visuals at all z-order levels:
                    return HitTestResultBehavior.Continue;
                //case IntersectionDetail.NotCalculated:
                    //break;
                default:
                    //break;
                    return HitTestResultBehavior.Stop;
            }
        }
    }
}
