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

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for NewTournamentWindow.xaml
    /// </summary>
    public partial class NewTournamentWindow : Window
    {
        public NewTournamentWindow()
        {
            InitializeComponent();
        }

        Tournaments _addedTournament;
        public Tournaments AddedTournament
        {
            get
            {
                return _addedTournament;
            }
        }

        private void button_AddNewTournament_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_City.Text))
            {
                MessageBox.Show("Enter your tournament's city");
                textBox_City.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_Name.Text))
            {
                MessageBox.Show("Enter your tournament's name");
                textBox_Name.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_Country.Text))
            {
                MessageBox.Show("Enter your tournament's country");
                textBox_Country.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_PrizeMoney.Text))
            {
                MessageBox.Show("Enter your tournament's prize money");
                textBox_PrizeMoney.Focus();
                return;

            }
            if (string.IsNullOrWhiteSpace(comboBoxDateMonth_1.Text))
            {
                MessageBox.Show("Choose your tournament's date");
                comboBoxDateMonth_1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBox_DateDay2.Text))
            {
                MessageBox.Show("Choose your tournament's date");
                comboBox_DateDay2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_DateDay_1.Text))
            {
                MessageBox.Show("Choose your tournament's date");
                comboBox_DateDay_1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_DateMonth2.Text))
            {
                MessageBox.Show("Choose your tournament's date");
                comboBox_DateMonth2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_PrizeMoney.Text))
            {
                MessageBox.Show("Choose currency of your tournament's przie money");
                comboBox_PrizeMoney.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBox_Surface.Text))
            {
                MessageBox.Show("Choose your tournament's surface");
                comboBox_Surface.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_Surface1.Text))
            {
                MessageBox.Show("Choose your tournament's surface ");
                comboBox_Surface1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox_Category.Text))
            {
                MessageBox.Show("Choose your tournament's surface ");
                comboBox_Surface1.Focus();
                return;
            }
            if(((comboBox_DateDay_1.Text == "30")||(comboBox_DateDay_1.Text == "31"))&&(comboBoxDateMonth_1.Text=="FEB"))
            {
                MessageBox.Show("Incorrect date ");
                return;
            }
            if (((comboBox_DateDay2.Text == "30") || (comboBox_DateDay2.Text == "31")) && (comboBox_DateMonth2.Text == "FEB"))
            {
                MessageBox.Show("Incorrect date ");
                return;
            }
            if ((comboBox_DateDay_1.Text == "31") && ((comboBoxDateMonth_1.Text == "APR")||(comboBoxDateMonth_1.Text=="JUN")||(comboBoxDateMonth_1.Text == "SEP")|| (comboBoxDateMonth_1.Text == "NOV")))
            {
                MessageBox.Show("Incorrect date ");
                return;
            }
            if ((comboBox_DateDay2.Text == "31") && ((comboBox_DateMonth2.Text == "APR") || (comboBox_DateMonth2.Text == "JUN") || (comboBox_DateMonth2.Text == "SEP") || (comboBox_DateMonth2.Text == "NOV")))
            {
                MessageBox.Show("Incorrect date ");
                return;
            }
            _addedTournament = new Tournaments(comboBox_DateDay_1.Text+" "+comboBoxDateMonth_1.Text+" - " +comboBox_DateDay2.Text+" "+comboBox_DateMonth2.Text, textBox_Name.Text,
            textBox_City.Text, textBox_Country.Text, comboBox_Surface.Text+" "+comboBox_Surface1.Text,  int.Parse(comboBox_Category.Text), comboBox_PrizeMoney.Text+textBox_PrizeMoney.Text);
            DialogResult = true;
        }
    }
}
