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
    /// Interaction logic for PlayerPage.xaml
    /// </summary>
    public partial class PlayerPage : Page
    {
        int count = 0;
        const string FileNameP = "../../players.txt";
        const string FileNameUP = "../../updPlayers.txt";
        const string FileNameC = "../../coaches.txt";


        List<Players> PlayersInfo = new List<Players>();
        List<Coaches> CoachesInfo = new List<Coaches>();
        

        public PlayerPage()
        {
            InitializeComponent();
            
 
    
            if (RegPages.MainPage.label_LOGGED.Visibility==Visibility.Visible)
            {
                buttonAdd.IsEnabled = true;
                buttonRemove.IsEnabled = true;
            }

        }

        private void WidthAnimationShowBtn()
        {
            DoubleAnimation show_width = new DoubleAnimation();
            show_width.From = buttonShowPlayers.ActualWidth;
            show_width.To = 125;
            show_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonShowPlayers.BeginAnimation(WidthProperty, show_width);
        }
        private void HeightAnimationShowBtn()
        {
            DoubleAnimation show_height = new DoubleAnimation();
            show_height.From = buttonShowPlayers.ActualWidth;
            show_height.To = 64;
            show_height.Duration = TimeSpan.FromSeconds(0.5);
           buttonShowPlayers.BeginAnimation(HeightProperty, show_height);
        }
        private void WidthAnimationRemoveBtn()
        {
            DoubleAnimation remove_width = new DoubleAnimation();
            remove_width.From = buttonRemove.ActualWidth;
            remove_width.To = 125;
            remove_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonRemove.BeginAnimation(WidthProperty, remove_width);

        }

        private void HeightAnimationRemoveBtn()
        {
            DoubleAnimation remove_height = new DoubleAnimation();
            remove_height.From = buttonRemove.ActualWidth;
            remove_height.To = 64;
            remove_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonRemove.BeginAnimation(HeightProperty, remove_height);
        }

        private void WidthAnimationAddBtn()
        {
            DoubleAnimation add_width = new DoubleAnimation();
            add_width.From = buttonAdd.ActualWidth;
            add_width.To = 125;
            add_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonAdd.BeginAnimation(WidthProperty, add_width);

        }
        private void HeightAnimationAddBtn()
        {
            DoubleAnimation add_height = new DoubleAnimation();
            add_height.From = buttonAdd.ActualWidth;
            add_height.To = 64;
            add_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonAdd.BeginAnimation(HeightProperty, add_height);
        }

        private void WidthAnimationSerializeBtn()
        {
            DoubleAnimation serialize_width = new DoubleAnimation();
            serialize_width.From = buttonSerialize.ActualWidth;
            serialize_width.To = 125;
            serialize_width.Duration = TimeSpan.FromSeconds(0.5);
           buttonSerialize.BeginAnimation(WidthProperty, serialize_width);

        }
        private void HeightAnimationSerializeBtn()
        {
            DoubleAnimation serialize_height = new DoubleAnimation();
            serialize_height.From = buttonSerialize.ActualWidth;
            serialize_height.To = 64;
            serialize_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonSerialize.BeginAnimation(HeightProperty, serialize_height);
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
        private void RefreshGrid()
        {
            gridPlayers.ItemsSource = null;
            gridPlayers.Columns.Clear();
            gridPlayers.ItemsSource = PlayersInfo;
        }



        private void button_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                {
                    gridPlayers.ItemsSource = null;
                    gridPlayers.Columns.Clear();
                    PlayersInfo.Clear();
                    CoachesInfo.Clear();
            

                }
                {
                    gridPlayers.ItemsSource = null;
                    gridPlayers.Columns.Clear();
                    PlayersInfo.Clear();

                    string[] playersMass = File.ReadAllLines(FileNameP, Encoding.GetEncoding(1251));
                    for (int i = 0; i < 100; i++)
                    {
                        string[] PlayersMass1 = playersMass[i].Split(new char[] { ';' });
                        string[] CoachesMass1 = playersMass[i + 100].Split(new char[] { ';' });
                        Coaches exampleC = new Coaches(CoachesMass1[0], CoachesMass1[1]);

                        Players exampleP = new Players(PlayersMass1[0], int.Parse(PlayersMass1[1]), PlayersMass1[2], PlayersMass1[3], int.Parse(PlayersMass1[4]), int.Parse(PlayersMass1[5]), int.Parse(PlayersMass1[6]), int.Parse(PlayersMass1[7]));
                        exampleP.Coach = exampleC.Name.ToString();
                        PlayersInfo.Add(exampleP);

                    }


                    gridPlayers.ItemsSource = PlayersInfo;
                    if (label_edit.Content.ToString() == "Edit mode")
                        buttonRemove.IsEnabled = true;
                }
                
                string[] names = new string[PlayersInfo.Count];
                for (int i = 0; i < PlayersInfo.Count; i++)
                {
                    names[i] = PlayersInfo[i].Name;

                }

                cbSearch.ItemsSource = names;
            }
            catch
            {
                MessageBox.Show("File wasn't loaded", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }






        }



     

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gridPlayers.ItemsSource == null)
                {
                    MessageBox.Show("List of players is empty! \nTry to load information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    buttonRemove.IsEnabled = false;
                }
                if ((gridPlayers.SelectedItem == null) && (gridPlayers.ItemsSource != null))
                {
                    MessageBox.Show("Choose a player that you want to remove", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Players selected_player = gridPlayers.SelectedItem as Players;
                for (int i = PlayersInfo.Count - 1; i >= 0; i--)
                {
                    if (PlayersInfo[i] == selected_player)
                    { PlayersInfo.Remove(PlayersInfo[i]); }
                }
                gridPlayers.ItemsSource = PlayersInfo;


            }
            catch
            {
                MessageBox.Show("Removing is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        public void NewPlayerAdded(Players newPlayer)
        {
            PlayersInfo.Add(newPlayer);
            gridPlayers.ItemsSource = null;
            gridPlayers.Columns.Clear();
            gridPlayers.ItemsSource = PlayersInfo;
            string[] names = new string[PlayersInfo.Count];
            for (int i = 0; i < PlayersInfo.Count; i++)
            {
                names[i] = PlayersInfo[i].Name;

            }

            cbSearch.ItemsSource = names;

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        { try
            {
                NavigationService.Navigate(RegPages.NewPlayerPage);
                RegPages.NewPlayerPage.textBoxAge.Clear();
                RegPages.NewPlayerPage.textBoxCoach.Clear();
                RegPages.NewPlayerPage.textBoxHeight.Clear();
                RegPages.NewPlayerPage.textBoxNameP.Clear();
                RegPages.NewPlayerPage.textBoxNationality.Clear();
                RegPages.NewPlayerPage.textBoxNationality_Coach.Clear();
                RegPages.NewPlayerPage.textBoxRank.Clear();
                RegPages.NewPlayerPage.textBoxTitles.Clear();
                RegPages.NewPlayerPage.textBoxWeight.Clear();
                RegPages.NewPlayerPage.comboBoxStrongHand.Text = "";
            }
            catch
            {
                MessageBox.Show("Adding function is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }

        private void buttonSaveInFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PlayersInfo.Count == 0)
                    MessageBox.Show("List of players is empty! \nTry to load information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
                else
            if ((radioButton_Serialize.IsChecked == true) && (radioButton_Deserialize.IsChecked == false))
                {

                    InfoSerializing serializePlayers = new InfoSerializing();
                    serializePlayers.Players = PlayersInfo;

                    using (var fs = new FileStream("../../players.xml", FileMode.Create))
                    {
                        XmlSerializer xmlPlayers = new XmlSerializer(typeof(InfoSerializing));
                        xmlPlayers.Serialize(fs, serializePlayers);
                        MessageBox.Show("List is serialized", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else if ((radioButton_Serialize.IsChecked == false) && (radioButton_Deserialize.IsChecked == true))
                {

                    InfoSerializing deserializePlayers;
                    using (var fs = new FileStream("../../players.xml", FileMode.Open))
                    {
                        XmlSerializer xmlPlayers = new XmlSerializer(typeof(InfoSerializing));
                        deserializePlayers = (InfoSerializing)xmlPlayers.Deserialize(fs);
                        MessageBox.Show("List is deserialized", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }

                else

                {
                    MessageBox.Show("Choose any option", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("List was not serialized/deserialized", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void radioButton_Deserialize_Checked(object sender, RoutedEventArgs e)
        {
            buttonSerialize.Content = "Deserialize";
        }

        private void radioButton_Serialize_Checked(object sender, RoutedEventArgs e)
        {
            buttonSerialize.Content = "Serialize";
        }


        private void buttonSearch_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                if (gridPlayers.ItemsSource == null)
                {
                    MessageBox.Show("List of players is empty!\nLoad information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbSearch.Text = "";
                }
                else
                if (cbSearch.SelectedItem == null)
                {
                    MessageBox.Show("Enter your player's name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbSearch.Focus();
                }
                else
                {
                    count = 0;
                    for (int i = 0; i < PlayersInfo.Count; i++)
                    {
                        if (cbSearch.Text == PlayersInfo[i].Name)
                        {
                            gridPlayers.ScrollIntoView(PlayersInfo[i]);
                            gridPlayers.SelectedItem = PlayersInfo[i];
                            cbSearch.Text = "";

                        }
                        else
                            count++;

                    }
                }
                if ((count == PlayersInfo.Count) && (count != 0) && (cbSearch.SelectedItem != null))
                {

                    MessageBox.Show("This player is not found in the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cbSearch.Text = "";
                    cbSearch.Focus();


                }
                if ((count == PlayersInfo.Count) && (count != 0) && (cbSearch.SelectedItem != null) && (label_edit.Content.ToString() == "Edit mode"))
                {
                    MessageBox.Show("This player is not found in the list\n\nYou can add him if you want", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                cbSearch.Text = "Enter your player's name";
                _name = false;
                cbSearch.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void buttonGOBACK_Click(object sender, RoutedEventArgs e)
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

        private void buttonShowPlayers_Enlarge(object sender, MouseEventArgs e)
        {
            HeightAnimationShowBtn();
            WidthAnimationShowBtn();
        }

        private void buttonShowPlayers_Back_to_size(object sender, MouseEventArgs e)
        {
            DoubleAnimation show_width = new DoubleAnimation();
            show_width.From = buttonShowPlayers.ActualWidth;
            show_width.To = 104;
            show_width.Duration = TimeSpan.FromMilliseconds(0.1);
        
            DoubleAnimation show_height = new DoubleAnimation();
            show_height.From = buttonShowPlayers.ActualWidth;
            show_height.To = 53;
            show_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonShowPlayers.BeginAnimation(WidthProperty, show_width);
            buttonShowPlayers.BeginAnimation(HeightProperty, show_height);
        }

        private void buttonRemove_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationRemoveBtn();
            WidthAnimationRemoveBtn();

        }

        private void buttonRemove_MouseLeave(object sender, MouseEventArgs e)
        {
            {
                DoubleAnimation remove_width = new DoubleAnimation();
                remove_width.From = buttonRemove.ActualWidth;
                remove_width.To = 104;
                remove_width.Duration = TimeSpan.FromMilliseconds(0.1);
                

            DoubleAnimation remove_height = new DoubleAnimation();
            remove_height.From = buttonRemove.ActualWidth;
            remove_height.To = 45;
            remove_height.Duration = TimeSpan.FromMilliseconds(0.1);
                buttonRemove.BeginAnimation(WidthProperty, remove_width);
                buttonRemove.BeginAnimation(HeightProperty, remove_height);
        }
    }

        private void buttonAdd_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationAddBtn();
            WidthAnimationAddBtn();
        }


        private void buttonSerialize_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationSerializeBtn();
            WidthAnimationSerializeBtn();
        }

        private void buttonSerialize_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation serialize_width = new DoubleAnimation();
            serialize_width.From = buttonSerialize.ActualWidth;
            serialize_width.To = 104;
            serialize_width.Duration = TimeSpan.FromMilliseconds(0.1);
            
            DoubleAnimation serialize_height = new DoubleAnimation();
            serialize_height.From = buttonSerialize.ActualHeight;
            serialize_height.To = 53;
            serialize_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonSerialize.BeginAnimation(WidthProperty, serialize_width);
            buttonSerialize.BeginAnimation(HeightProperty, serialize_height);
        
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
                search_height.To = 53;
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
            go_back_height.To = 53;
            go_back_height.Duration = TimeSpan.FromMilliseconds(0.1);
            
        
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = buttonGOBACK.ActualWidth;
            go_back_width.To = 104;
            go_back_width.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonGOBACK.BeginAnimation(WidthProperty, go_back_width);
            buttonGOBACK.BeginAnimation(HeightProperty, go_back_height);

        }

        private void buttonAdd_MouseLeave_1(object sender, MouseEventArgs e)
        {
            DoubleAnimation add_width = new DoubleAnimation();
            add_width.From = buttonAdd.ActualWidth;
            add_width.To = 104;
            add_width.Duration = TimeSpan.FromMilliseconds(0.1);


            DoubleAnimation add_height = new DoubleAnimation();
            add_height.From = buttonAdd.ActualHeight;
            add_height.To = 45;
            add_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonAdd.BeginAnimation(WidthProperty, add_width);
            buttonAdd.BeginAnimation(HeightProperty, add_height);
        }
    }
    }

