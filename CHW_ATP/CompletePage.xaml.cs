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

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for CompletePage.xaml
    /// </summary>
    public partial class CompletePage : Page
    {
        public CompletePage()
        {
            InitializeComponent();
            
        }

        private void button_COMPLETE_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            m.label_LOGGED.Visibility = Visibility.Visible;
            m.buttonAUTHORIZATION.IsEnabled = false;
            m.buttonREGISTRATION.IsEnabled = false;
            m.buttonLOGOUT.Visibility = Visibility.Visible;
            
            
  
            
        }
    }
}
