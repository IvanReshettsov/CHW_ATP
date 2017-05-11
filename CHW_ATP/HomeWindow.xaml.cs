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
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        int count=0;
        const string FileNameP = "../../players.txt";
        const string FileNameUP = "../../updPlayers.txt";
        const string FileNameC = "../../coaches.txt";

        List<Players> PlayersInfo = new List<Players>();
        List<Coaches> CoachesInfo = new List<Coaches>();
        
        public HomeWindow()
        {
            InitializeComponent();
            

        }
        

        private void RefreshGrid()
        {
            gridPlayers.ItemsSource = null;
            gridPlayers.Columns.Clear();
            gridPlayers.ItemsSource = PlayersInfo;
        }

        

        private void button_Click(object sender, RoutedEventArgs e)
        
        {
            {
                gridPlayers.ItemsSource = null;
                gridPlayers.Columns.Clear();
                PlayersInfo.Clear();

                string[] playersMass = File.ReadAllLines(FileNameP, Encoding.GetEncoding(1251));
                for (int i = 0; i < playersMass.Length; i++)
                {
                    string[] PlayersMass1 = playersMass[i].Split(new char[] { ';' });
                    Players exampleP = new Players(PlayersMass1[0], int.Parse(PlayersMass1[1]), PlayersMass1[2], PlayersMass1[3], int.Parse(PlayersMass1[4]), int.Parse(PlayersMass1[5]), int.Parse(PlayersMass1[6]), int.Parse(PlayersMass1[7]));
                    PlayersInfo.Add(exampleP);


                }

                gridPlayers.ItemsSource = PlayersInfo;
                if (label_edit.Content.ToString() == "Edit mode")
                    buttonRemove.IsEnabled = true;
            }
        }
       


        private void gridPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Players selected_player = gridPlayers.SelectedItem as Players;
            //MessageBox.Show(" Name: " + selected_player.Name + "\n Age " + selected_player.Age + "\n Nationality: " + selected_player.Nationality
            //    + "\n Strong Hand: " + selected_player.StrongHand + "\n Rank: " + " #" + selected_player.Rating + "\n Height: " + selected_player.Height + " cm" + "\n Weight: " + selected_player.Weight + " kg" + "\n Titles: " + selected_player.Titles);

        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (gridPlayers.ItemsSource == null)
            {
                MessageBox.Show("List of players is empty! \nTry to load information from the file firstly.", "Error");
                    buttonRemove.IsEnabled = false;
            }
            if ((gridPlayers.SelectedItem==null)&&(gridPlayers.ItemsSource!=null))
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

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var addPlayer = new NewPlayer();
            if (addPlayer.ShowDialog().Value)
            {
                PlayersInfo.Add(addPlayer.AddedPlayer);
            }
            gridPlayers.ItemsSource = PlayersInfo;
        }

        private void buttonSaveInFile_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersInfo.Count == 0)
                MessageBox.Show("List of players is empty! \nTry to load information from the file firstly.", "Error");
            //придумать анимацию с выделением/миганием кнопки "Show"
            else
            if ((radioButton_Serialize.IsChecked == true)&&(radioButton_Deserialize.IsChecked==false))
            {
                
                InfoSerializing serializePlayers = new InfoSerializing();
                serializePlayers.Players = PlayersInfo;

                using (var fs = new FileStream("players.xml", FileMode.Create))
                {
                    XmlSerializer xmlPlayers = new XmlSerializer(typeof(InfoSerializing));
                    xmlPlayers.Serialize(fs, serializePlayers);
                    MessageBox.Show("List is serialized", "Information",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
            else if ((radioButton_Serialize.IsChecked == false) && (radioButton_Deserialize.IsChecked == true))
            {
                
                InfoSerializing deserializePlayers;
                using (var fs = new FileStream("players.xml", FileMode.Open))
                {
                    XmlSerializer xmlPlayers = new XmlSerializer(typeof(InfoSerializing));
                    deserializePlayers = (InfoSerializing)xmlPlayers.Deserialize(fs);
                    MessageBox.Show("List is deserialized", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            
            else
          
            {
                MessageBox.Show("Choose any option", "Error!");
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
            if (gridPlayers.ItemsSource == null)
            {
                MessageBox.Show("Grid is empty!\nLoad information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            if (gridPlayers.ItemsSource == null)
            {
                MessageBox.Show("List of players is empty!\nLoad information from the file firstly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                MessageBox.Show("Enter your player's name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxSearch.Focus();
            }
            else
            {
                count = 0;
                for (int i = 0; i < PlayersInfo.Count; i++)
                {
                    if (textBoxSearch.Text == PlayersInfo[i].Name)
                    {
                        gridPlayers.ScrollIntoView(PlayersInfo[i]);
                        gridPlayers.SelectedItem = PlayersInfo[i];
                        textBoxSearch.Clear();

                    }
                    else
                        count++;

                }
            }
            if ((count==PlayersInfo.Count)&&(count!=0)&&(!string.IsNullOrWhiteSpace(textBoxSearch.Text)))
            {

                MessageBox.Show("This player is not found in the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxSearch.Clear();
                textBoxSearch.Focus();
                
                //придумать анимацию с выделением кнопки ADD
            }
            else if (label_edit.Content.ToString()=="Edit mode")
            {
                MessageBox.Show("This player is not found in the list\n\nYou can add him if you want", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxSearch.Clear();
                textBoxSearch.Focus();
                
            }
        }
    }
    }











