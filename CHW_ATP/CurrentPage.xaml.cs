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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for CurrentPage.xaml
    /// </summary>
    public partial class CurrentPage : Page
    {
        public CurrentPage()
        {
            InitializeComponent();
        }
        private void WidthAnimationGoBackBtn()
        {
            DoubleAnimation register_width = new DoubleAnimation();
            register_width.From = button_GOBACK.ActualWidth;
            register_width.To = 135;
            register_width.Duration = TimeSpan.FromSeconds(0.5);
           button_GOBACK.BeginAnimation(WidthProperty, register_width);
        }
        private void HeightAnimationGoBackBtn()
        {
            DoubleAnimation register_height = new DoubleAnimation();
            register_height.From = button_GOBACK.ActualWidth;
            register_height.To = 55;
            register_height.Duration = TimeSpan.FromSeconds(0.5);
            button_GOBACK.BeginAnimation(HeightProperty, register_height);
        }
        private void button_COMPLETE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(RegPages.MainPage);
            }
            catch
            {
                MessageBox.Show("Navigation is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_GOBACK_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationGoBackBtn();
            WidthAnimationGoBackBtn();
        }

        private void button_GOBACK_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation register_width = new DoubleAnimation();
            register_width.From = button_GOBACK.ActualWidth;
            register_width.To = 117;
            register_width.Duration = TimeSpan.FromMilliseconds(0.1);

            DoubleAnimation register_height = new DoubleAnimation();
            register_height.From = button_GOBACK.ActualWidth;
            register_height.To = 35;
            register_height.Duration = TimeSpan.FromMilliseconds(0.1);
            button_GOBACK.BeginAnimation(WidthProperty, register_width);
            button_GOBACK.BeginAnimation(HeightProperty, register_height);
        }
    }
}
