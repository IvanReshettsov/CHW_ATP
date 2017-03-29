using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    /// Interaction logic for TournamentsWindow.xaml
    /// </summary>
    public partial class TournamentsWindow : Window
    {
        const string FileNameT = "tournaments.txt";
        List<Tournaments> TournamentsInfo = new List<Tournaments>();
        public TournamentsWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            gridTournaments.ItemsSource = null;
            gridTournaments.Columns.Clear();
            TournamentsInfo.Clear();
            string[] tournamentsMass = File.ReadAllLines(FileNameT, Encoding.GetEncoding(1251));
            for (int i = 0; i < tournamentsMass.Length; i++)
            {
                string[] TournamentsMass1 = tournamentsMass[i].Split(new char[] { ';' });
                Tournaments exampleT = new Tournaments(TournamentsMass1[0], TournamentsMass1[1], TournamentsMass1[2], TournamentsMass1[3], TournamentsMass1[4], int.Parse(TournamentsMass1[5]), TournamentsMass1[6]);
                TournamentsInfo.Add(exampleT);


            }
            
            gridTournaments.ItemsSource = TournamentsInfo;

        }

        private void gridTournaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tournaments selected_tournament = gridTournaments.SelectedItem as Tournaments;
            MessageBox.Show(" Date: " + selected_tournament.Date +"\n Name: " + selected_tournament.TName + "\n City: " + selected_tournament.City+ "\n Country: " + selected_tournament.Country
                + "\n Surface: " + selected_tournament.Surface + "\n Category: " + " ATP " + selected_tournament.Category + "\n Prize Money: " + selected_tournament.Prize_Money);

        }
    }
}
