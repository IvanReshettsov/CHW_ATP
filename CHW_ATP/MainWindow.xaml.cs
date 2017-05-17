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
using System.Windows.Media.Animation;
//СДЕЛАТЬ АНИМАЦИЮ ИЗМЕНЕНИЯ ФОНА В СОБЫТИИ MOUSEENTER КАЖДОЙ КНОПКИ!!!!!

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
        int color = 0;
        public MainWindow()
        {

            InitializeComponent();
            label_LOGGED.Visibility = Visibility.Hidden;
        }

        //    Background = new SolidColorBrush(SystemColors.ControlColor);

        //    ColorAnimation animation = new ColorAnimation();
        //    animation.To = Colors.LightSkyBlue;
        //    animation.Duration = new Duration(TimeSpan.FromSeconds(3));
        //    Storyboard.SetTarget(animation, MainGrid);
        //    Storyboard.SetTargetProperty(animation, new PropertyPath(SolidColorBrush.ColorProperty));


        //    //для второй анимации
        //    //Storyboard.SetTarget(scd_animation, MainGrid);
        //    //Storyboard.SetTargetProperty(scd_animation, new PropertyPath(SolidColorBrush.ColorProperty));


        //    Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        //    animation.Completed += ScdAnimation;

        //    ColorAnimation scd_animation = new ColorAnimation();
        //    scd_animation.From = Colors.LightSkyBlue;
        //    scd_animation.To = Colors.MistyRose;
        //    scd_animation.Duration = new Duration(TimeSpan.FromSeconds(3));

        //    Background.BeginAnimation(SolidColorBrush.ColorProperty, scd_animation);

        //    //////Background.BeginAnimation(SolidColorBrush.ColorProperty, scd_animation);
        //    //////var storyboard = new Storyboard();

        //    //////storyboard.Children.Add(animation);
        //    //////storyboard.Children.Add(scd_animation);
        //    //////storyboard.Children = new TimelineCollection { animation, scd_animation, };

        //    //////storyboard.Begin(this);



        //    //////ColorAnimation ca = new ColorAnimation(Colors.Red, Colors.Blue, new Duration(TimeSpan.FromSeconds(4)));
        //    //////Storyboard.SetTarget(ca, this);
        //    //////Storyboard.SetTargetProperty(ca, new PropertyPath("Background.Color"));


        //    //////Storyboard stb = new Storyboard();
        //    //////stb.Children.Add(ca);


        //    //////ColorAnimation ca1 = new ColorAnimation(Colors.Blue, Colors.Green, new Duration(TimeSpan.FromSeconds(4)));
        //    //////Storyboard.SetTarget(ca1, this);
        //    //////Storyboard.SetTargetProperty(ca1, new PropertyPath("Background.Color"));


        //    //////stb.Children = new TimelineCollection { ca, ca1 };

        //    //////stb.Begin();


        //}

        //private void ScdAnimation(object sender, EventArgs e)
        //{
        //    ColorAnimation scd_animation = new ColorAnimation();
        //    scd_animation.From = Colors.LightSkyBlue;
        //    scd_animation.To = Colors.MistyRose;
        //    scd_animation.Duration = new Duration(TimeSpan.FromSeconds(3));
        //    Background.BeginAnimation(SolidColorBrush.ColorProperty, scd_animation);
        //}

        private void EnableAuthorization()
        {
            buttonAUTHORIZATION.IsEnabled = true;
            buttonREGISTRATION.IsEnabled = true;
        }
        private void WidthAnimationPlayersBtn()
        {
            DoubleAnimation players_width = new DoubleAnimation();
            players_width.From = buttonPLAYERS.ActualWidth;
            players_width.To = 125;
            players_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonPLAYERS.BeginAnimation(WidthProperty, players_width);
        }
        private void HeightAnimationPlayersBtn()
        {
            DoubleAnimation players_height = new DoubleAnimation();
            players_height.From = buttonPLAYERS.ActualWidth;
            players_height.To = 64;
            players_height.Duration = TimeSpan.FromSeconds(0.5);
           buttonPLAYERS.BeginAnimation(HeightProperty, players_height);
        }
        private void WidthAnimationTournamentsBtn()
        {
            DoubleAnimation tournaments_width = new DoubleAnimation();
            tournaments_width.From = buttonPLAYERS.ActualWidth;
            tournaments_width.To = 125;
            tournaments_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonTOURNAMENTS.BeginAnimation(WidthProperty, tournaments_width);
            
        }

        private void HeightAnimationTournamentsBtn()
        {
            DoubleAnimation tournaments_height = new DoubleAnimation();
            tournaments_height.From = buttonPLAYERS.ActualWidth;
            tournaments_height.To = 64;
            tournaments_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonTOURNAMENTS.BeginAnimation(HeightProperty, tournaments_height);
        }
        
        private void WidthAnimationLoginBtn()
        {
            DoubleAnimation log_in_width = new DoubleAnimation();
            log_in_width.From = buttonAUTHORIZATION.ActualWidth;
            log_in_width.To = 125;
            log_in_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonAUTHORIZATION.BeginAnimation(WidthProperty, log_in_width);
           
        }
        private void HeightAnimationLoginBtn()
        {
            DoubleAnimation log_in_height = new DoubleAnimation();
            log_in_height.From = buttonAUTHORIZATION.ActualWidth;
            log_in_height.To = 64;
            log_in_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonAUTHORIZATION.BeginAnimation(HeightProperty, log_in_height);
        }

        private void WidthAnimationRegisterBtn()
        {
            DoubleAnimation register_width = new DoubleAnimation();
            register_width.From = buttonREGISTRATION.ActualWidth;
            register_width.To = 125;
            register_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonREGISTRATION.BeginAnimation(WidthProperty, register_width);
            
        }
        private void HeightAnimationRegisterBtn()
        {
            DoubleAnimation register_height = new DoubleAnimation();
            register_height.From = buttonREGISTRATION.ActualWidth;
            register_height.To = 64;
            register_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonREGISTRATION.BeginAnimation(HeightProperty, register_height);
        }

        private void HeightAnimationLogoutBtn()
        {
            DoubleAnimation log_out_height = new DoubleAnimation();
            log_out_height.From = buttonLOGOUT.ActualWidth;
            log_out_height.To = 64;
            log_out_height.Duration = TimeSpan.FromSeconds(0.5);
            buttonLOGOUT.BeginAnimation(HeightProperty, log_out_height);
        }

        private void WidthAnimationLogoutBtn()
        {
            DoubleAnimation log_out_width = new DoubleAnimation();
            log_out_width.From = buttonLOGOUT.ActualWidth;
            log_out_width.To = 125;
            log_out_width.Duration = TimeSpan.FromSeconds(0.5);
            buttonLOGOUT.BeginAnimation(WidthProperty, log_out_width);
        }
        private void buttonPLAYERS_Click(object sender, RoutedEventArgs e)
        {
           
            HomeWindow homeWindow = new HomeWindow();
            
                if (label_LOGGED.Visibility == Visibility.Visible)
                    homeWindow.label_edit.Content = "Edit mode";
                else
                {
                    homeWindow.label_edit.Content = "Read-only mode";
                    homeWindow.buttonAdd.IsEnabled = false;
                    homeWindow.buttonRemove.IsEnabled = false;
                }
            homeWindow.ShowDialog();


            //homeWindow.gridPlayers.ItemsSource = null;
            //homeWindow.gridPlayers.Columns.Clear();
            //PlayersInfo.Clear();
            //string[] playersMass = File.ReadAllLines(FileNameP, Encoding.GetEncoding(1251));
            //for (int i = 0; i < playersMass.Length; i++)
            //{
            //    string[] PlayersMass1 = playersMass[i].Split(new char[] { ';' });
            //    Players exampleP = new Players(PlayersMass1[0], int.Parse(PlayersMass1[1]), PlayersMass1[2], PlayersMass1[3], int.Parse(PlayersMass1[4]), int.Parse(PlayersMass1[5]), int.Parse(PlayersMass1[6]), int.Parse(PlayersMass1[7]));
            //    PlayersInfo.Add(exampleP);


            //}
            //homeWindow.gridPlayers.ItemsSource = PlayersInfo;

        }



        private void buttonTOURNAMENTS_Click_1(object sender, RoutedEventArgs e)
        {
            
            TournamentsWindow tournamentsWindow = new TournamentsWindow();
            
                if (label_LOGGED.Visibility == Visibility.Visible)
                    tournamentsWindow.label_edit.Content = "Edit mode";
                else
                {
                    tournamentsWindow.label_edit.Content = "Read-only mode";
                    tournamentsWindow.button_Add.IsEnabled = false;
                    tournamentsWindow.button_Remove.IsEnabled = false;
                }
            tournamentsWindow.ShowDialog();


            //tournamentsWindow.gridTournaments.ItemsSource = null;
            //tournamentsWindow.gridTournaments.Columns.Clear();
            //TournamentsInfo.Clear();
            //string[] tournamentsMass = File.ReadAllLines(FileNameT, Encoding.GetEncoding(1251));
            //for (int i = 0; i < tournamentsMass.Length; i++)
            //{
            //    string[] TournamentsMass1 = tournamentsMass[i].Split(new char[] { ';' });
            //    Tournaments exampleT = new Tournaments(TournamentsMass1[0], TournamentsMass1[1], TournamentsMass1[2], TournamentsMass1[3], TournamentsMass1[4], int.Parse(TournamentsMass1[5]), TournamentsMass1[6]);
            //    TournamentsInfo.Add(exampleT);


            //}

            //tournamentsWindow.gridTournaments.ItemsSource = TournamentsInfo;
        }

        private void buttonREGISTRATION_Click(object sender, RoutedEventArgs e)
        {
            if (label_LOGGED.Visibility == Visibility.Visible)
                MessageBox.Show("You are already logged in the system", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                RegisterWindow registerWindow = new RegisterWindow();
                registerWindow.Show();
                registerWindow.frameMain.Navigate(new LoginPage());
                
            }
        }

        private void buttonAUTHORIZATION_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
           
                registerWindow.Show();
                registerWindow.frameMain.Navigate(new AuthorizePage());
            


        }

        private void buttonLOGOUT_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?\nIf you log out,you will not be able to edit information", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
           
                if (result == MessageBoxResult.Yes)
            {
                label_LOGGED.Visibility = Visibility.Hidden;
                EnableAuthorization();
                buttonLOGOUT.Visibility = Visibility.Hidden;
            }
            

        }

        private void buttonPLAYERS_ENLARGE(object sender, MouseEventArgs e)
        {
           
            HeightAnimationPlayersBtn();
            WidthAnimationPlayersBtn();

        }

        private void buttonPLAYERS_Back_To_Size(object sender, MouseEventArgs e)
        {
            DoubleAnimation players_width = new DoubleAnimation();
            players_width.From = buttonPLAYERS.ActualWidth;
            players_width.To = 107;
            players_width.Duration = TimeSpan.FromMilliseconds(0.1);
            
            DoubleAnimation players_height = new DoubleAnimation();
            players_height.From = buttonPLAYERS.ActualWidth;
            players_height.To = 40;
            players_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonPLAYERS.BeginAnimation(WidthProperty, players_width);
            buttonPLAYERS.BeginAnimation(HeightProperty, players_height);
        

    }

        private void buttonTOURNAMENTS_ENLARGE(object sender, MouseEventArgs e)
        {
            HeightAnimationTournamentsBtn();
            WidthAnimationTournamentsBtn();
        }

        private void buttonTOURNAMENTS_Back_To_Size(object sender, MouseEventArgs e)
        {
            DoubleAnimation tournaments_width = new DoubleAnimation();
            tournaments_width.From = buttonTOURNAMENTS.ActualWidth;
            tournaments_width.To = 107;
            tournaments_width.Duration = TimeSpan.FromMilliseconds(0.1);

            DoubleAnimation tournaments_height = new DoubleAnimation();
            tournaments_height.From = buttonTOURNAMENTS.ActualWidth;
            tournaments_height.To = 40;
            tournaments_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonTOURNAMENTS.BeginAnimation(WidthProperty, tournaments_width);
            buttonTOURNAMENTS.BeginAnimation(HeightProperty, tournaments_height);
        }

        private void buttonLOGIN_ENLARGE(object sender, MouseEventArgs e)
        {
            HeightAnimationLoginBtn();
            WidthAnimationLoginBtn();
        }

        private void buttonLOGIN_Back_To_Size(object sender, MouseEventArgs e)
        {
            DoubleAnimation log_in_width = new DoubleAnimation();
            log_in_width.From = buttonAUTHORIZATION.ActualWidth;
            log_in_width.To = 80;
            log_in_width.Duration = TimeSpan.FromMilliseconds(0.1);

            DoubleAnimation log_in_height = new DoubleAnimation();
            log_in_height.From = buttonAUTHORIZATION.ActualWidth;
            log_in_height.To = 46;
            log_in_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonAUTHORIZATION.BeginAnimation(WidthProperty, log_in_width);
            buttonAUTHORIZATION.BeginAnimation(HeightProperty, log_in_height);
        }

        private void buttonREGISTER_ENLARGE(object sender, MouseEventArgs e)
        {
            HeightAnimationRegisterBtn();
            WidthAnimationRegisterBtn();
        }

        private void buttonREGISTER_Back_To_Size(object sender, MouseEventArgs e)
        {
            DoubleAnimation register_width = new DoubleAnimation();
            register_width.From = buttonREGISTRATION.ActualWidth;
            register_width.To = 80;
            register_width.Duration = TimeSpan.FromMilliseconds(0.1);

            DoubleAnimation register_height = new DoubleAnimation();
            register_height.From = buttonREGISTRATION.ActualWidth;
            register_height.To = 46;
            register_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonREGISTRATION.BeginAnimation(WidthProperty, register_width);
            buttonREGISTRATION.BeginAnimation(HeightProperty, register_height);
        }

        private void buttonLOGOUT_ENLARGE(object sender, MouseEventArgs e)
        {
            HeightAnimationLogoutBtn();
            WidthAnimationLogoutBtn();
            
        }

        private void buttonLOGOUT_Back_To_Size(object sender, MouseEventArgs e)
        {
            DoubleAnimation log_out_width = new DoubleAnimation();
            log_out_width.From = buttonLOGOUT.ActualWidth;
            log_out_width.To = 80;
            log_out_width.Duration = TimeSpan.FromMilliseconds(0.1);

            DoubleAnimation log_out_height = new DoubleAnimation();
            log_out_height.From = buttonLOGOUT.ActualWidth;
            log_out_height.To = 46;
            log_out_height.Duration = TimeSpan.FromMilliseconds(0.1);
            buttonLOGOUT.BeginAnimation(WidthProperty, log_out_width);
            buttonLOGOUT.BeginAnimation(HeightProperty, log_out_height);
        }

        
          
        
    }
}
