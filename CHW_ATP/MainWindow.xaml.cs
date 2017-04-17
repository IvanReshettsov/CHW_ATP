using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FileNameP = "players.txt";
        List<Players> PlayersInfo = new List<Players>();
        const string FileNameT = "tournaments.txt";
        List<Tournaments> TournamentsInfo = new List<Tournaments>();

        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void buttonPLAYERS_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
            homeWindow.gridPlayers.ItemsSource = null;
            homeWindow.gridPlayers.Columns.Clear();
            PlayersInfo.Clear();
            string[] playersMass = File.ReadAllLines(FileNameP, Encoding.GetEncoding(1251));
            for (int i = 0; i < playersMass.Length; i++)
            {
                string[] PlayersMass1 = playersMass[i].Split(new char[] { ';' });
                Players exampleP = new Players(PlayersMass1[0], int.Parse(PlayersMass1[1]), PlayersMass1[2], PlayersMass1[3], int.Parse(PlayersMass1[4]), int.Parse(PlayersMass1[5]), int.Parse(PlayersMass1[6]), int.Parse(PlayersMass1[7]));
                PlayersInfo.Add(exampleP);


            }
            homeWindow.gridPlayers.ItemsSource = PlayersInfo;
            
        }

       

        private void buttonTOURNAMENTS_Click_1(object sender, RoutedEventArgs e)
        {
            
            TournamentsWindow tournamentsWindow = new TournamentsWindow();
            tournamentsWindow.Show();
            tournamentsWindow.gridTournaments.ItemsSource = null;
            tournamentsWindow.gridTournaments.Columns.Clear();
            TournamentsInfo.Clear();
            string[] tournamentsMass = File.ReadAllLines(FileNameT, Encoding.GetEncoding(1251));
            for (int i = 0; i < tournamentsMass.Length; i++)
            {
                string[] TournamentsMass1 = tournamentsMass[i].Split(new char[] { ';' });
                Tournaments exampleT = new Tournaments(TournamentsMass1[0], TournamentsMass1[1], TournamentsMass1[2], TournamentsMass1[3], TournamentsMass1[4], int.Parse(TournamentsMass1[5]), TournamentsMass1[6]);
                TournamentsInfo.Add(exampleT);


            }

            tournamentsWindow.gridTournaments.ItemsSource = TournamentsInfo;
        }

        private void buttonREGISTRATION_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }
    }
}
