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
using System.Xml.Serialization;

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for TournamentPage.xaml
    /// </summary>
    public partial class TournamentPage : Page
    {
        const string FileNameT = "../../tournaments.txt";
        const string FileNameUT = "../../updTournaments.txt";

        List<Tournaments> TournamentsInfo = new List<Tournaments>();
        public TournamentPage()
        {
            InitializeComponent();
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gridTournaments.ItemsSource = null;
                gridTournaments.Columns.Clear();
                TournamentsInfo.Clear();
                string[] tournamentsMass = File.ReadAllLines(FileNameT, Encoding.GetEncoding(1251));
                for (int i = 0; i < 72; i++)
                {
                    string[] TournamentsMass1 = tournamentsMass[i].Split(new char[] { ';' });
                    string[] SupervisorsMass1 = tournamentsMass[i + 72].Split(new char[] { ';' });
                    Supervisors exampleS = new Supervisors(SupervisorsMass1[0], SupervisorsMass1[1]);
                    Tournaments exampleT = new Tournaments(TournamentsMass1[0], TournamentsMass1[1], TournamentsMass1[2], TournamentsMass1[3], TournamentsMass1[4], int.Parse(TournamentsMass1[5]), TournamentsMass1[6]);
                    exampleT.Supervisor = exampleS.Name.ToString();

                    TournamentsInfo.Add(exampleT);                    

                }

                gridTournaments.ItemsSource = TournamentsInfo;
                if (label_edit.Content.ToString() == "Edit mode")
                    button_Remove.IsEnabled = true;

            }
            catch
            {
                MessageBox.Show("File wasn't loaded", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void gridTournaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Tournaments selected_tournament = gridTournaments.SelectedItem as Tournaments;
            //MessageBox.Show(" Date: " + selected_tournament.Date +"\n Name: " + selected_tournament.TName + "\n City: " + selected_tournament.City+ "\n Country: " + selected_tournament.Country
            //    + "\n Surface: " + selected_tournament.Surface + "\n Category: " + " ATP " + selected_tournament.Category + "\n Prize Money: " + selected_tournament.Prize_Money);

        }

        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {

            if ((gridTournaments.SelectedItem == null) && (gridTournaments.ItemsSource != null))
            {
                MessageBox.Show("Choose a player that you want to remove", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            if (gridTournaments.ItemsSource == null)
            {
                MessageBox.Show("List of players is empty! \nTry to load information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
            // анимация кнопки show
            Tournaments selected_tournament = gridTournaments.SelectedItem as Tournaments;
            for (int i = TournamentsInfo.Count - 1; i >= 0; i--)
            {
                if (TournamentsInfo[i] == selected_tournament)
                { TournamentsInfo.Remove(TournamentsInfo[i]); }
            }
            gridTournaments.ItemsSource = TournamentsInfo;
        }
        public void NewTournamentAdded(Tournaments newTournament)
        {
            RegPages.NewTournamentPage.textBox_City.Clear();
            RegPages.NewTournamentPage.textBox_Country.Clear();
            RegPages.NewTournamentPage.textBox_Name.Clear();
            RegPages.NewTournamentPage.textBox_PrizeMoney.Clear();
            RegPages.NewTournamentPage.textBox_Supervisor.Clear();
            RegPages.NewTournamentPage.textBox_SupervisorNation.Clear();
            RegPages.NewTournamentPage.comboBoxDateMonth_1.Text="";
            RegPages.NewTournamentPage.comboBox_Category.Text = "";
            RegPages.NewTournamentPage.comboBox_DateDay2.Text = "";
            RegPages.NewTournamentPage.comboBox_DateDay_1.Text = "";
            RegPages.NewTournamentPage.comboBox_DateMonth2.Text = "";
            RegPages.NewTournamentPage.comboBox_PrizeMoney.Text = "";
            RegPages.NewTournamentPage.comboBox_Surface.Text = "";
            RegPages.NewTournamentPage.comboBox_Surface1.Text = "";

            TournamentsInfo.Add(newTournament);
            gridTournaments.ItemsSource = null;
            gridTournaments.Columns.Clear();
            gridTournaments.ItemsSource = TournamentsInfo;
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(RegPages.NewTournamentPage);
        }

        private void buttonSaveTournaments_Click(object sender, RoutedEventArgs e)
        {
            if (TournamentsInfo.Count == 0)
                MessageBox.Show("List of tournaments is empty! \nTry to load information from the file firstly.", "Error");
            //придумать анимацию с выделением/миганием кнопки "Show"
            else
            if ((radioButton_Serialize.IsChecked == true) && (radioButton_Deserialize.IsChecked == false))
            {
                InfoSerializing serializeTournaments = new InfoSerializing();
                serializeTournaments.Tournaments = TournamentsInfo;

                using (var fs = new FileStream("tournaments.xml", FileMode.Create))
                {
                    XmlSerializer xmlTournaments = new XmlSerializer(typeof(InfoSerializing));
                    xmlTournaments.Serialize(fs, serializeTournaments);
                    MessageBox.Show("List is serialized", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if ((radioButton_Serialize.IsChecked == false) && (radioButton_Deserialize.IsChecked == true))
            {
                InfoSerializing deserializeTournaments;
                using (var fs = new FileStream("tournaments.xml", FileMode.Open))
                {
                    XmlSerializer xmlTournaments = new XmlSerializer(typeof(InfoSerializing));
                    deserializeTournaments = (InfoSerializing)xmlTournaments.Deserialize(fs);
                    MessageBox.Show("List is deserialized", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }

            else
            {
                MessageBox.Show("Choose any option", "Error!");
            }
        }

        private void radioButton_Serialize_Checked(object sender, RoutedEventArgs e)
        {
            buttonSerializeTournaments.Content = "Serialize";
        }

        private void radioButton_Deserialize_Checked(object sender, RoutedEventArgs e)
        {
            buttonSerializeTournaments.Content = "Deserialize";
        }

        private void buttonGOBACK_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(RegPages.MainPage);
        }
    }
}
