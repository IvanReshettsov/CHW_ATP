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

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for NewPlayerPage.xaml
    /// </summary>
    public partial class NewPlayerPage : Page
    {
        public NewPlayerPage()
        {
            InitializeComponent();
        }

        Players _addedPlayer;
        List<Coaches> CoachesInfo = new List<Coaches>();
        const string FileNameC = "../../coaches.txt";

        public Players AddedPlayer
        {
            get
            {
                return _addedPlayer;
            }
        }

        private void buttonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            uint ageP;
            uint rank;
            uint titles;
            uint height;
            uint weight;
            if (string.IsNullOrWhiteSpace(textBoxNameP.Text))
            {
                MessageBox.Show("Enter your player's name");
                textBoxNameP.Focus();
                return;
            }
            if (!uint.TryParse(textBoxAge.Text, out ageP))
            {
                MessageBox.Show("Player's age is incorrect");
                textBoxAge.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxNationality.Text))
            {
                MessageBox.Show("Enter your player's nation");
                textBoxNationality.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxStrongHand.Text))
            {
                MessageBox.Show("Choose your player's strong hand");
                comboBoxStrongHand.Focus();
                return;
            }
            if (!uint.TryParse(textBoxRank.Text, out rank))
            {
                MessageBox.Show("Player's rank is incorrect");
                textBoxRank.Focus();
                return;
            }
            if (!uint.TryParse(textBoxHeight.Text, out height))
            {
                MessageBox.Show("Player's height is incorrect");
                textBoxHeight.Focus();
                return;
            }
            if (!uint.TryParse(textBoxWeight.Text, out weight))
            {
                MessageBox.Show("Player's weight is incorrect");
                textBoxWeight.Focus();
                return;
            }
            if (!uint.TryParse(textBoxTitles.Text, out titles))
            {
                MessageBox.Show("Player's number of tiles is incorrect");
                textBoxTitles.Focus();
                return;
            }

            _addedPlayer = new Players(textBoxNameP.Text, int.Parse(textBoxAge.Text), textBoxNationality.Text, comboBoxStrongHand.Text, int.Parse(textBoxRank.Text), int.Parse(textBoxHeight.Text), int.Parse(textBoxWeight.Text), int.Parse(textBoxTitles.Text));
            _addedPlayer.Coach = textBoxCoach.Text;
            string[] coachesMass = File.ReadAllLines(FileNameC, Encoding.GetEncoding(1251));
            for (int i = 0; i < coachesMass.Length; i++)
            {
                string[] CoachesMass1 = coachesMass[i].Split(new char[] { ';' });
                Coaches exampleC = new Coaches(CoachesMass1[0], CoachesMass1[1]);
                CoachesInfo.Add(exampleC);
            }
            int count = 0;
            int Count = 0;
            for (int i = 0; i < CoachesInfo.Count; i++)
            {
                if (textBoxCoach.Text == CoachesInfo[i].Name)
                    count += 1;
                else
                {
                    Count += 1;
                }
            }

            if (Count == CoachesInfo.Count)
            {
                Coaches newcoach = new Coaches(textBoxCoach.Text, textBoxNationality_Coach.Text);
                CoachesInfo.Add(newcoach);
            }

            RegPages.PlayerPage.NewPlayerAdded(_addedPlayer);
            NavigationService.GoBack();

        }

        private void buttonGOBACK_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
