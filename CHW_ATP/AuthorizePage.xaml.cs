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
using System.Security.Cryptography;
using System.Windows.Media.Animation;

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for AuthorizePage.xaml
    /// </summary>
    public partial class AuthorizePage : Page
    {
        List<User> User = new List<User>();
        const string FileNameUT = "../../users.txt";

        private void WidthAnimationRegisterBtn()
        {
            DoubleAnimation register_width = new DoubleAnimation();
            register_width.From = button_register.ActualWidth;
            register_width.To = 132;
            register_width.Duration = TimeSpan.FromSeconds(0.5);
            button_register.BeginAnimation(WidthProperty, register_width);
        }
        private void HeightAnimationRegisterBtn()
        {
            DoubleAnimation register_height = new DoubleAnimation();
            register_height.From = button_register.ActualWidth;
            register_height.To = 55;
            register_height.Duration = TimeSpan.FromSeconds(0.5);
            button_register.BeginAnimation(HeightProperty, register_height);
        }
        private void WidthAnimationGoBackBtn()
        {
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = button_GOBACK.ActualWidth;
            go_back_width.To = 132;
            go_back_width.Duration = TimeSpan.FromSeconds(0.5);
            button_GOBACK.BeginAnimation(WidthProperty, go_back_width);
        }
        private void HeightAnimationGoBackBtn()
        {
            DoubleAnimation go_back_height = new DoubleAnimation();
            go_back_height.From = button_GOBACK.ActualWidth;
            go_back_height.To = 55;
            go_back_height.Duration = TimeSpan.FromSeconds(0.5);
            button_GOBACK.BeginAnimation(HeightProperty, go_back_height);
        }


        public AuthorizePage()
        {
            InitializeComponent();
            textBox_Login.Focus();
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        private void ClearData()
        {
            textBox_Login.Clear();
            passwordBox.Clear();
            textBox_Login.Focus();
        }

        private void button_register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((string.IsNullOrWhiteSpace(textBox_Login.Text)) || (string.IsNullOrWhiteSpace(passwordBox.Password)))
                {
                    MessageBox.Show("Enter login and password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox_Login.Focus();
                }
                else
                {
                    User.Clear();
                    string[] users = File.ReadAllLines(FileNameUT, Encoding.GetEncoding(1251));
                    for (int i = 0; i < users.Length; i++)
                    {
                        string[] users1 = users[i].Split(new char[] { ' ' });
                        User exampleU = new User(users1[0], users1[1]);
                        User.Add(exampleU);


                    }


                    int countLGerrors = 0;
                    int countPWerrors = 0;
                    int countSuccess = 0;
                    for (int i = 0; i < User.Count; i++)

                    {
                        if (textBox_Login.Text == User[i].Name)
                        {
                            var hash = CalculateHash(User[i].Password);
                            if (CalculateHash(passwordBox.Password) == hash)
                            {
                                NavigationService.Navigate(RegPages.CompletePage);
                                countSuccess += 1;
                            }
                            else
                                countPWerrors += 1;


                        }
                        else
                            countLGerrors += 1;
                    }
                    if (countLGerrors == User.Count)
                    {
                        MessageBox.Show("Incorrect login", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        ClearData();

                    }
                    if ((countPWerrors != 0) && (countSuccess == 0))
                    {
                        MessageBox.Show("Incorrect password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        passwordBox.Clear();
                        passwordBox.Focus();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Authorization was not completed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }  
        }

        private void button_COMPLETE_Click(object sender, RoutedEventArgs e)
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

        private void button_GOBACK_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationGoBackBtn();
            WidthAnimationGoBackBtn();
        }

        private void button_GOBACK_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation go_back_width = new DoubleAnimation();
            go_back_width.From = button_GOBACK.ActualWidth;
            go_back_width.To = 112;
            go_back_width.Duration = TimeSpan.FromMilliseconds(0.1);
            
        
            DoubleAnimation go_back_height = new DoubleAnimation();
            go_back_height.From = button_GOBACK.ActualWidth;
            go_back_height.To =33;
            go_back_height.Duration = TimeSpan.FromMilliseconds(0.1);
            button_GOBACK.BeginAnimation(WidthProperty, go_back_width);
            button_GOBACK.BeginAnimation(HeightProperty, go_back_height);
        
    }

        private void button_register_MouseEnter(object sender, MouseEventArgs e)
        {
            HeightAnimationRegisterBtn();
            WidthAnimationRegisterBtn();
        }

        private void button_register_MouseLeave(object sender, MouseEventArgs e)
        {
            DoubleAnimation register_width = new DoubleAnimation();
            register_width.From = button_register.ActualWidth;
            register_width.To = 112;
            register_width.Duration = TimeSpan.FromMilliseconds(0.1);
        
            DoubleAnimation register_height = new DoubleAnimation();
            register_height.From = button_register.ActualWidth;
            register_height.To = 33;
            register_height.Duration = TimeSpan.FromMilliseconds(0.1);
            button_register.BeginAnimation(WidthProperty, register_width);
            button_register.BeginAnimation(HeightProperty, register_height);
        
    }
        






    }
}

