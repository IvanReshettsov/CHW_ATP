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


namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        const string FileNameP = "players.txt";
        List<Players> PlayersInfo = new List<Players>();
        public HomeWindow()
        {
            InitializeComponent();
        }
          
        private void button_Click(object sender, RoutedEventArgs e)
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
            gridPlayers.ItemsSource = null;
            gridPlayers.Columns.Clear();
            gridPlayers.ItemsSource = PlayersInfo;

        }


        private void gridPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Players selected_player = gridPlayers.SelectedItem as Players;
            MessageBox.Show(" Name: " + selected_player.Name + "\n Age " + selected_player.Age + "\n Nationality: " + selected_player.Nationality
                + "\n Strong Hand: " + selected_player.StrongHand + "\n Rank: " + " #" + selected_player.Rating + "\n Height: " + selected_player.Height + " cm" + "\n Weight: " + selected_player.Weight + " kg" + "\n Titles: " + selected_player.Titles);

        }
    }
}
