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
using System.IO;
using System.Windows.Media.Animation;

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for NewTournamentPage.xaml
    /// </summary>
    public partial class NewTournamentPage : Page
    {
        public NewTournamentPage()
        {
            InitializeComponent();
        }

        Tournaments _addedTournament;
        List<Supervisors> SupervisorsInfo = new List<Supervisors>();
        const string FileNameS = "../../supervisors.txt";

        public Tournaments AddedTournament
        {
            get
            {
                return _addedTournament;
            }
        }
        private void WidthAnimationAddBtn()
        {
            DoubleAnimation add_width = new DoubleAnimation();
            add_width.From = button_AddNewTournament.ActualWidth;
            add_width.To = 190;
            add_width.Duration = TimeSpan.FromSeconds(0.5);
            button_AddNewTournament.BeginAnimation(WidthProperty, add_width);
        }
        private void HeightAnimationAddBtn()
        {
            DoubleAnimation add_height = new DoubleAnimation();
            add_height.From = button_AddNewTournament.ActualWidth;
            add_height.To = 66;
            add_height.Duration = TimeSpan.FromSeconds(0.5);
            button_AddNewTournament.BeginAnimation(HeightProperty, add_height);
        }
        private void WidthAnimationGoBackBtn()
        {
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = buttonGOBACK.ActualWidth;
            go_back_width.To = 190;
            go_back_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonGOBACK.BeginAnimation(WidthProperty, go_back_width);
        }
        private void HeightAnimationGoBackBtn()
        {
            DoubleAnimation go_back_height = new DoubleAnimation();
            go_back_height.From = buttonGOBACK.ActualWidth;
            go_back_height.To = 66;
            go_back_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonGOBACK.BeginAnimation(HeightProperty, go_back_height);
        }

        private void button_AddNewTournament_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            if (string.IsNullOrWhiteSpace(textBox_City.Text))
            {
                MessageBox.Show("Enter your tournament's city", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_City.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_Name.Text))
            {
                MessageBox.Show("Enter your tournament's name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_Name.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_Country.Text))
            {
                MessageBox.Show("Enter your tournament's country", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_Country.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_PrizeMoney.Text))
            {
                MessageBox.Show("Enter your tournament's prize money", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_PrizeMoney.Focus();
                return;

            }
            if (string.IsNullOrWhiteSpace(textBox_Supervisor.Text))
            {
                MessageBox.Show("Enter your tournament's supervisor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_Supervisor.Focus();
                return;

            }
            if (string.IsNullOrWhiteSpace(textBox_SupervisorNation.Text))
            {
                MessageBox.Show("Enter your supervisor's native country", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_SupervisorNation.Focus();
                return;

            }
            if (string.IsNullOrWhiteSpace(comboBoxDateMonth_1.Text))
            {
                MessageBox.Show("Choose your tournament's date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBoxDateMonth_1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBox_DateDay2.Text))
            {
                MessageBox.Show("Choose your tournament's date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox_DateDay2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_DateDay_1.Text))
            {
                MessageBox.Show("Choose your tournament's date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox_DateDay_1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_DateMonth2.Text))
            {
                MessageBox.Show("Choose your tournament's date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox_DateMonth2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_PrizeMoney.Text))
            {
                MessageBox.Show("Choose currency of your tournament's przie money", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox_PrizeMoney.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBox_Surface.Text))
            {
                MessageBox.Show("Choose your tournament's surface", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox_Surface.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_Surface1.Text))
            {
                MessageBox.Show("Choose your tournament's surface", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox_Surface1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_Category.Text))
            {
                MessageBox.Show("Choose your tournament's surface", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                comboBox_Surface1.Focus();
                return;
            }
            if (((comboBox_DateDay_1.Text == "30") || (comboBox_DateDay_1.Text == "31")) && (comboBoxDateMonth_1.Text == "FEB"))
            {
                MessageBox.Show("Incorrect date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (((comboBox_DateDay2.Text == "30") || (comboBox_DateDay2.Text == "31")) && (comboBox_DateMonth2.Text == "FEB"))
            {
                MessageBox.Show("Incorrect date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if ((comboBox_DateDay_1.Text == "31") && ((comboBoxDateMonth_1.Text == "APR") || (comboBoxDateMonth_1.Text == "JUN") || (comboBoxDateMonth_1.Text == "SEP") || (comboBoxDateMonth_1.Text == "NOV")))
            {
                MessageBox.Show("Incorrect date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if ((comboBox_DateDay2.Text == "31") && ((comboBox_DateMonth2.Text == "APR") || (comboBox_DateMonth2.Text == "JUN") || (comboBox_DateMonth2.Text == "SEP") || (comboBox_DateMonth2.Text == "NOV")))
            {
                MessageBox.Show("Incorrect date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _addedTournament = new Tournaments(comboBox_DateDay_1.Text + " " + comboBoxDateMonth_1.Text + " - " + comboBox_DateDay2.Text + " " + comboBox_DateMonth2.Text, textBox_Name.Text,
            textBox_City.Text, textBox_Country.Text, comboBox_Surface.Text + " " + comboBox_Surface1.Text, int.Parse(comboBox_Category.Text), comboBox_PrizeMoney.Text + textBox_PrizeMoney.Text);
            _addedTournament.Supervisor = textBox_Supervisor.Text;


            string[] supervisorsMass = File.ReadAllLines(FileNameS, Encoding.GetEncoding(1251));
            for (int i = 0; i < supervisorsMass.Length; i++)
            {
                string[] SupervisorsMass1 = supervisorsMass[i].Split(new char[] { ';' });
                Supervisors exampleS = new Supervisors(SupervisorsMass1[0], SupervisorsMass1[1]);
                SupervisorsInfo.Add(exampleS);
            }
            int count = 0;
            int Count = 0;
            for (int i = 0; i < SupervisorsInfo.Count; i++)
            {
                if (textBox_Supervisor.Text == SupervisorsInfo[i].Name)
                    count += 1;
                else
                {
                    Count += 1;
                }
            }

            if (Count == SupervisorsInfo.Count)
            {
                Supervisors newsupervisor = new Supervisors(textBox_Supervisor.Text, textBox_SupervisorNation.Text);
                SupervisorsInfo.Add(newsupervisor);
            }

            RegPages.TournamentPage.NewTournamentAdded(_addedTournament);
            NavigationService.GoBack();
        }
            catch
            {
                MessageBox.Show("Add function is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonGOBACK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Navigation is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button_AddNewTournament_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationAddBtn();
            WidthAnimationAddBtn();
        }

        private void button_AddNewTournament_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation add_width = new DoubleAnimation();
            add_width.From = button_AddNewTournament.ActualWidth;
            add_width.To = 174;
            add_width.Duration = TimeSpan.FromMilliseconds(0.1);
        
        
            DoubleAnimation add_height = new DoubleAnimation();
            add_height.From = button_AddNewTournament.ActualWidth;
            add_height.To = 53;
            add_height.Duration = TimeSpan.FromMilliseconds(0.1);
            button_AddNewTournament.BeginAnimation(WidthProperty, add_width);
            button_AddNewTournament.BeginAnimation(HeightProperty, add_height);
        }

        private void buttonGOBACK_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationGoBackBtn();
            WidthAnimationGoBackBtn();
        }

        private void buttonGOBACK_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = buttonGOBACK.ActualWidth;
            go_back_width.To = 174;
            go_back_width.Duration = TimeSpan.FromMilliseconds(0.1);
            
        
            DoubleAnimation go_back_height = new DoubleAnimation();
            go_back_height.From = buttonGOBACK.ActualWidth;
            go_back_height.To = 53;
            go_back_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonGOBACK.BeginAnimation(WidthProperty, go_back_width);
            buttonGOBACK.BeginAnimation(HeightProperty, go_back_height);
        
    }
    }
}
