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
            var addPlayer = new NewPlayer();
            if (addPlayer.ShowDialog().Value)
            {
                //PlayersInfo.Add(addPlayer.)
            }
            
        }
        private void gridPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Players selected_player = gridPlayers.SelectedItem as Players;
            MessageBox.Show(" Name: " + selected_player.Name + "\n Age " + selected_player.Age + "\n Nationality: " + selected_player.Nationality
                + "\n Strong Hand: " + selected_player.StrongHand + "\n Rank: " + " #" + selected_player.Rating + "\n Height: " + selected_player.Height + " cm" + "\n Weight: " + selected_player.Weight + " kg" + "\n Titles: " + selected_player.Titles);

        }
    }
}
