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
using System.Windows.Media.Animation;


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

        private void WidthAnimationAddBtn()
        {
            DoubleAnimation add_width = new DoubleAnimation();
            add_width.From = buttonAddPlayer.ActualWidth;
            add_width.To = 190;
            add_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonAddPlayer.BeginAnimation(WidthProperty, add_width);
        }
        private void HeightAnimationAddBtn()
        {
            DoubleAnimation add_height = new DoubleAnimation();
            add_height.From = buttonAddPlayer.ActualWidth;
            add_height.To = 66;
            add_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonAddPlayer.BeginAnimation(HeightProperty, add_height);
        }
        private void WidthAnimationGoBackBtn()
        {
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = buttonGOBACK.ActualWidth;
            go_back_width.To = 190;
            go_back_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonGOBACK.BeginAnimation(WidthProperty, go_back_width);
        }
        private void HeightAnimationGoBackBtn()
        {
            DoubleAnimation go_back_height = new DoubleAnimation();
            go_back_height.From = buttonGOBACK.ActualWidth;
            go_back_height.To = 66;
            go_back_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonGOBACK.BeginAnimation(HeightProperty, go_back_height);
        }

        public Players AddedPlayer
        {
            get
            {
                return _addedPlayer;
            }
        }

        private void buttonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint ageP;
                uint rank;
                uint titles;
                uint height;
                uint weight;
                if (string.IsNullOrWhiteSpace(textBoxNameP.Text))
                {
                    MessageBox.Show("Enter your player's name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBoxNameP.Focus();
                    return;
                }
                if (!uint.TryParse(textBoxAge.Text, out ageP))
                {
                    MessageBox.Show("Player's age is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBoxAge.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxNationality.Text))
                {
                    MessageBox.Show("Enter your player's nation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBoxNationality.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxCoach.Text))
                {
                    MessageBox.Show("Enter your player's coach", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBoxCoach.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxNationality_Coach.Text))
                {
                    MessageBox.Show("Enter your coach's nation", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBoxNationality_Coach.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBoxStrongHand.Text))
                {
                    MessageBox.Show("Choose your player's strong hand", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    comboBoxStrongHand.Focus();
                    return;
                }
                if (!uint.TryParse(textBoxRank.Text, out rank))
                {
                    MessageBox.Show("Player's rank is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBoxRank.Focus();
                    return;
                }
                if (!uint.TryParse(textBoxHeight.Text, out height))
                {
                    MessageBox.Show("Player's height is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBoxHeight.Focus();
                    return;
                }
                if (!uint.TryParse(textBoxWeight.Text, out weight))
                {
                    MessageBox.Show("Player's weight is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBoxWeight.Focus();
                    return;
                }
                if (!uint.TryParse(textBoxTitles.Text, out titles))
                {
                    MessageBox.Show("Player's number of tiles is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            catch
            {
                MessageBox.Show("Add function is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



private void buttonGOBACK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Navigation is impossible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAddPlayer_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationAddBtn();
            WidthAnimationAddBtn();
        }

        private void buttonAddPlayer_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation add_width = new DoubleAnimation();
            add_width.From = buttonAddPlayer.ActualWidth;
            add_width.To = 174;
            add_width.Duration = TimeSpan.FromMilliseconds(0.1);
            
            DoubleAnimation add_height = new DoubleAnimation();
            add_height.From = buttonAddPlayer.ActualWidth;
            add_height.To = 53;
            add_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonAddPlayer.BeginAnimation(WidthProperty, add_width);
            buttonAddPlayer.BeginAnimation(HeightProperty, add_height);
        }

        private void buttonGOBACK_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationGoBackBtn();
            WidthAnimationGoBackBtn();
        }

        private void buttonGOBACK_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = buttonGOBACK.ActualWidth;
            go_back_width.To = 174;
            go_back_width.Duration = TimeSpan.FromMilliseconds(0.1);
           
        
            DoubleAnimation go_back_height = new DoubleAnimation();
            go_back_height.From = buttonGOBACK.ActualWidth;
            go_back_height.To =53;
            go_back_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonGOBACK.BeginAnimation(WidthProperty, go_back_width);
            buttonGOBACK.BeginAnimation(HeightProperty, go_back_height);
        }
    }
}
