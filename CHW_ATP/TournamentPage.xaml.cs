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
using System.Windows.Media.Animation;

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for TournamentPage.xaml
    /// </summary>
    public partial class TournamentPage : Page
    {
        const string FileNameT = "../../tournaments.txt";
        const string FileNameUT = "../../updTournaments.txt";
        int count;
        List<Tournaments> TournamentsInfo = new List<Tournaments>();
        public TournamentPage()
        {
            InitializeComponent();
        }

        private void WidthAnimationShowBtn()
        {
            DoubleAnimation show_width = new DoubleAnimation();
            show_width.From =  buttonShowTournaments.ActualWidth;
            show_width.To = 125;
            show_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonShowTournaments.BeginAnimation(WidthProperty, show_width);
        }
        private void HeightAnimationShowBtn()
        {
            DoubleAnimation show_height = new DoubleAnimation();
            show_height.From = buttonShowTournaments.ActualWidth;
            show_height.To = 64;
            show_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonShowTournaments.BeginAnimation(HeightProperty, show_height);
        }
        private void WidthAnimationRemoveBtn()
        {
            DoubleAnimation remove_width = new DoubleAnimation();
            remove_width.From = button_Remove.ActualWidth;
            remove_width.To = 125;
            remove_width.Duration = TimeSpan.FromSeconds(0.5);
            button_Remove.BeginAnimation(WidthProperty, remove_width);

        }

        private void HeightAnimationRemoveBtn()
        {
            DoubleAnimation remove_height = new DoubleAnimation();
            remove_height.From = button_Remove.ActualWidth;
            remove_height.To = 64;
            remove_height.Duration = TimeSpan.FromSeconds(0.5);
            button_Remove.BeginAnimation(HeightProperty, remove_height);
        }

        private void WidthAnimationAddBtn()
        {
            DoubleAnimation add_width = new DoubleAnimation();
            add_width.From = button_Add.ActualWidth;
            add_width.To = 125;
            add_width.Duration = TimeSpan.FromSeconds(0.5);
            button_Add.BeginAnimation(WidthProperty, add_width);

        }
        private void HeightAnimationAddBtn()
        {
            DoubleAnimation add_height = new DoubleAnimation();
            add_height.From = button_Add.ActualWidth;
            add_height.To = 64;
            add_height.Duration = TimeSpan.FromSeconds(0.5);
            button_Add.BeginAnimation(HeightProperty, add_height);
        }

        private void WidthAnimationSerializeBtn()
        {
            DoubleAnimation serialize_width = new DoubleAnimation();
            serialize_width.From = buttonSerializeTournaments.ActualWidth;
            serialize_width.To = 125;
            serialize_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonSerializeTournaments.BeginAnimation(WidthProperty, serialize_width);

        }
        private void HeightAnimationSerializeBtn()
        {
            DoubleAnimation serialize_height = new DoubleAnimation();
            serialize_height.From = buttonSerializeTournaments.ActualWidth;
            serialize_height.To = 64;
            serialize_height.Duration = TimeSpan.FromSeconds(0.5);
           buttonSerializeTournaments.BeginAnimation(HeightProperty, serialize_height);
        }

        private void HeightAnimationSearchBtn()
        {
            DoubleAnimation search_height = new DoubleAnimation();
            search_height.From = buttonSearch.ActualWidth;
            search_height.To = 64;
            search_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonSearch.BeginAnimation(HeightProperty, search_height);
        }

        private void WidthAnimationSearchBtn()
        {
            DoubleAnimation search_width = new DoubleAnimation();
            search_width.From = buttonSearch.ActualWidth;
            search_width.To = 125;
            search_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonSearch.BeginAnimation(WidthProperty, search_width);
        }

        private void HeightAnimationGoBackBtn()
        {
            DoubleAnimation go_back_height = new DoubleAnimation();
            go_back_height.From = buttonGOBACK.ActualWidth;
            go_back_height.To = 64;
            go_back_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonGOBACK.BeginAnimation(HeightProperty, go_back_height);
        }

        private void WidthAnimationGoBackBtn()
        {
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = buttonGOBACK.ActualWidth;
            go_back_width.To = 125;
            go_back_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonGOBACK.BeginAnimation(WidthProperty, go_back_width);
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

                string[] names = new string[TournamentsInfo.Count];
                for (int i = 0; i < TournamentsInfo.Count; i++)
                {
                    names[i] = TournamentsInfo[i].TName;

                }

                cbSearch.ItemsSource = names;

            }
            catch
            {
                MessageBox.Show("File wasn't loaded", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        

        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((gridTournaments.SelectedItem == null) && (gridTournaments.ItemsSource != null))
                {
                    MessageBox.Show("Choose a player that you want to remove", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


                }
                if (gridTournaments.ItemsSource == null)
                {
                    MessageBox.Show("List of players is empty! \nTry to load information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); ;
                }
               
                Tournaments selected_tournament = gridTournaments.SelectedItem as Tournaments;
                for (int i = TournamentsInfo.Count - 1; i >= 0; i--)
                {
                    if (TournamentsInfo[i] == selected_tournament)
                    { TournamentsInfo.Remove(TournamentsInfo[i]); }
                }
                gridTournaments.ItemsSource = TournamentsInfo;
            }
            catch
            {
                MessageBox.Show("Removing is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void NewTournamentAdded(Tournaments newTournament)
        { 
            TournamentsInfo.Add(newTournament);
            gridTournaments.ItemsSource = null;
            gridTournaments.Columns.Clear();
            gridTournaments.ItemsSource = TournamentsInfo;
            string[] names = new string[TournamentsInfo.Count];
            for (int i = 0; i < TournamentsInfo.Count; i++)
            {
                names[i] = TournamentsInfo[i].TName;

            }

            cbSearch.ItemsSource = names;
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegPages.NewTournamentPage.textBox_City.Clear();
                RegPages.NewTournamentPage.textBox_Country.Clear();
                RegPages.NewTournamentPage.textBox_Name.Clear();
                RegPages.NewTournamentPage.textBox_PrizeMoney.Clear();
                RegPages.NewTournamentPage.textBox_Supervisor.Clear();
                RegPages.NewTournamentPage.textBox_SupervisorNation.Clear();
                RegPages.NewTournamentPage.comboBoxDateMonth_1.Text = "";
                RegPages.NewTournamentPage.comboBox_Category.Text = "";
                RegPages.NewTournamentPage.comboBox_DateDay2.Text = "";
                RegPages.NewTournamentPage.comboBox_DateDay_1.Text = "";
                RegPages.NewTournamentPage.comboBox_DateMonth2.Text = "";
                RegPages.NewTournamentPage.comboBox_PrizeMoney.Text = "";
                RegPages.NewTournamentPage.comboBox_Surface.Text = "";
                RegPages.NewTournamentPage.comboBox_Surface1.Text = "";
                NavigationService.Navigate(RegPages.NewTournamentPage);
            }
            catch
            {
                MessageBox.Show("Add function is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            }

        private void buttonSaveTournaments_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TournamentsInfo.Count == 0)
                MessageBox.Show("List of tournaments is empty! \nTry to load information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          
            else
            if ((radioButton_Serialize.IsChecked == true) && (radioButton_Deserialize.IsChecked == false))
            {
                InfoSerializing serializeTournaments = new InfoSerializing();
                serializeTournaments.Tournaments = TournamentsInfo;

                using (var fs = new FileStream("../../tournaments.xml", FileMode.Create))
                {
                    XmlSerializer xmlTournaments = new XmlSerializer(typeof(InfoSerializing));
                    xmlTournaments.Serialize(fs, serializeTournaments);
                    MessageBox.Show("List is serialized", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if ((radioButton_Serialize.IsChecked == false) && (radioButton_Deserialize.IsChecked == true))
            {
                InfoSerializing deserializeTournaments;
                using (var fs = new FileStream("../../tournaments.xml", FileMode.Open))
                {
                    XmlSerializer xmlTournaments = new XmlSerializer(typeof(InfoSerializing));
                    deserializeTournaments = (InfoSerializing)xmlTournaments.Deserialize(fs);
                    MessageBox.Show("List is deserialized", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }

            else
            {
                MessageBox.Show("Choose any option", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
            catch
            {
                MessageBox.Show("List was not serialized/deserialized", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void buttonSearch_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                if (gridTournaments.ItemsSource == null)
                {
                    MessageBox.Show("List of tournaments is empty!\nLoad information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbSearch.Text = "";
                }
                else
                if (cbSearch.SelectedItem == null)
                {
                    MessageBox.Show("Enter your tournament's name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbSearch.Focus();
                }
                else
                {
                    count = 0;
                    for (int i = 0; i < TournamentsInfo.Count; i++)
                    {
                        if (cbSearch.Text == TournamentsInfo[i].TName)
                        {
                            gridTournaments.ScrollIntoView(TournamentsInfo[i]);
                            gridTournaments.SelectedItem = TournamentsInfo[i];
                            cbSearch.Text = "";
                            

                        }
                        else
                            count++;

                    }
                }
                if ((count == TournamentsInfo.Count) && (count != 0) && (cbSearch.SelectedItem != null))
                {

                    MessageBox.Show("This tournament is not found in the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbSearch.Text = "";
                    cbSearch.Focus();


                }
                if ((count == TournamentsInfo.Count) && (count != 0) && (cbSearch.SelectedItem != null) && (label_edit.Content.ToString() == "Edit mode"))
                {
                    MessageBox.Show("This tournament is not found in the list\n\nYou can add it if you want", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbSearch.Text = "";
                    cbSearch.Focus();

                }

            }
            catch
            {
                MessageBox.Show("Search is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        bool _name = false;

        private void cb_Search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_name)
            {
                cbSearch.Text = "";
                cbSearch.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void cb_Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cbSearch.SelectedItem != null)
                _name = true;
            else
            {
                cbSearch.Text = "Enter your tournament's name";
                _name = false;
                cbSearch.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void buttonGOBACK_Click(object sender, RoutedEventArgs e)
        { try

            {
                NavigationService.Navigate(RegPages.MainPage);
            }


            catch
            {
                MessageBox.Show("Navigation is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
    
        }

        private void buttonShowTournaments_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationShowBtn();
            WidthAnimationShowBtn();
        }

        private void buttonShowTournaments_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation show_width = new DoubleAnimation();
            show_width.From = buttonShowTournaments.ActualWidth;
            show_width.To = 104;
            show_width.Duration = TimeSpan.FromMilliseconds(0.1);
            
        
            DoubleAnimation show_height = new DoubleAnimation();
            show_height.From = buttonShowTournaments.ActualWidth;
            show_height.To = 54;
            show_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonShowTournaments.BeginAnimation(WidthProperty, show_width);
            buttonShowTournaments.BeginAnimation(HeightProperty, show_height);
        }

        private void button_Remove_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationRemoveBtn();
            WidthAnimationRemoveBtn();

        }

        private void button_Remove_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation remove_width = new DoubleAnimation();
            remove_width.From = button_Remove.ActualWidth;
            remove_width.To = 104;
            remove_width.Duration = TimeSpan.FromMilliseconds(0.1);
            

            DoubleAnimation remove_height = new DoubleAnimation();
            remove_height.From = button_Remove.ActualWidth;
            remove_height.To = 54;
            remove_height.Duration = TimeSpan.FromMilliseconds(0.1);
            button_Remove.BeginAnimation(WidthProperty, remove_width);
            button_Remove.BeginAnimation(HeightProperty, remove_height);
        }

        private void button_Add_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationAddBtn();
            WidthAnimationAddBtn();
        }

        private void button_Add_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation add_width = new DoubleAnimation();
            add_width.From = button_Add.ActualWidth;
            add_width.To = 104;
            add_width.Duration = TimeSpan.FromMilliseconds(0.1);
        
            DoubleAnimation add_height = new DoubleAnimation();
            add_height.From = button_Add.ActualWidth;
            add_height.To = 54;
            add_height.Duration = TimeSpan.FromMilliseconds(0.1);
            button_Add.BeginAnimation(WidthProperty, add_width);
            button_Add.BeginAnimation(HeightProperty, add_height);
        }

        private void buttonSerializeTournaments_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationSerializeBtn();
            WidthAnimationSerializeBtn();
        }

        private void buttonSerializeTournaments_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation serialize_width = new DoubleAnimation();
            serialize_width.From = buttonSerializeTournaments.ActualWidth;
            serialize_width.To = 104;
            serialize_width.Duration = TimeSpan.FromMilliseconds(0.1);
            

        
            DoubleAnimation serialize_height = new DoubleAnimation();
            serialize_height.From = buttonSerializeTournaments.ActualWidth;
            serialize_height.To = 54;
            serialize_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonSerializeTournaments.BeginAnimation(WidthProperty, serialize_width);
            buttonSerializeTournaments.BeginAnimation(HeightProperty, serialize_height);
        }

        private void buttonSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationSearchBtn();
            WidthAnimationSearchBtn();
        }

        private void buttonSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation search_height = new DoubleAnimation();
            search_height.From = buttonSearch.ActualWidth;
            search_height.To = 54;
            search_height.Duration = TimeSpan.FromMilliseconds(0.1);
            
        
            DoubleAnimation search_width = new DoubleAnimation();
            search_width.From = buttonSearch.ActualWidth;
            search_width.To = 104;
            search_width.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonSearch.BeginAnimation(WidthProperty, search_width);
            buttonSearch.BeginAnimation(HeightProperty, search_height);
        }
    

        private void buttonGOBACK_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationGoBackBtn();
            WidthAnimationGoBackBtn();
        }

        private void buttonGOBACK_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation go_back_height = new DoubleAnimation();
            go_back_height.From = buttonGOBACK.ActualWidth;
            go_back_height.To = 54;
            go_back_height.Duration = TimeSpan.FromMilliseconds(0.1);
            
        
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = buttonGOBACK.ActualWidth;
            go_back_width.To = 104;
            go_back_width.Duration = TimeSpan.FromMilliseconds(0.5);
            buttonGOBACK.BeginAnimation(WidthProperty, go_back_width);
            buttonGOBACK.BeginAnimation(HeightProperty, go_back_height);

        }
    }
}
