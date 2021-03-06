﻿using System;
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
using System.Windows.Media.Animation;

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        const string FileNameP = "players.txt";
        List<Players> PlayersInfo = new List<Players>();
        const string FileNameT = "tournaments.txt";
        List<Tournaments> TournamentsInfo = new List<Tournaments>();
        public MainPage()
        {

            InitializeComponent();
            label_LOGGED.Visibility = Visibility.Hidden;
        }

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
            if (label_LOGGED.Visibility == Visibility.Visible)
            {
                RegPages.PlayerPage.label_edit.Content = "Edit mode";
                RegPages.PlayerPage.buttonAdd.IsEnabled = true;
                RegPages.PlayerPage.buttonRemove.IsEnabled = true;
                NavigationService.Navigate(RegPages.PlayerPage); 
            }
            else
            {
                RegPages.PlayerPage.label_edit.Content = "Read-only mode";
                RegPages.PlayerPage.buttonAdd.IsEnabled = false;
                RegPages.PlayerPage.buttonRemove.IsEnabled = false;
                NavigationService.Navigate(RegPages.PlayerPage);
            }

   
        }



        private void buttonTOURNAMENTS_Click_1(object sender, RoutedEventArgs e)
        {



            if (label_LOGGED.Visibility == Visibility.Visible)
            {
                RegPages.TournamentPage.label_edit.Content = "Edit mode";
                RegPages.TournamentPage.button_Add.IsEnabled = true;
                RegPages.TournamentPage.button_Remove.IsEnabled = true;
                NavigationService.Navigate(RegPages.TournamentPage);
            }
            else
            {
                RegPages.TournamentPage.label_edit.Content = "Read-only mode";
                RegPages.TournamentPage.button_Add.IsEnabled = false;
                RegPages.TournamentPage.button_Remove.IsEnabled = false;
                NavigationService.Navigate(RegPages.TournamentPage);
            }
       
        }

        private void buttonREGISTRATION_Click(object sender, RoutedEventArgs e)
        {
            if (label_LOGGED.Visibility == Visibility.Visible)
                MessageBox.Show("You are already logged in the system", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else
            {
                
             NavigationService.Navigate(RegPages.LoginPage);
                RegPages.LoginPage.textBox_Login.Clear();
                RegPages.LoginPage.passwordBox.Clear();
            }
        }

        private void buttonAUTHORIZATION_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(RegPages.AuthorizePage);
            RegPages.AuthorizePage.textBox_Login.Clear();
            RegPages.AuthorizePage.passwordBox.Clear();



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
