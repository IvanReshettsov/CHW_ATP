using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        List<User> User = new List<User>();
        List<User> ExistedUsers = new List<User>();
        const string FileNameUT = "../../users.txt";
        public LoginPage()
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
            //try
            //{
                ExistedUsers.Clear();
                string[] accounts = File.ReadAllLines(FileNameUT, Encoding.GetEncoding(1251));
                for (int i = 0; i < accounts.Length; i++)
                {
                    string[] Accounts = accounts[i].Split(new char[] { ' ' });
                    User exampleA = new User(Accounts[0], Accounts[1]);
                    ExistedUsers.Add(exampleA);


                }
                
                
            

            //if (FileNameUT.Length != 0)
            //{
            //    File.Delete(FileNameUT);
            //}

            using (StreamWriter wrPlayer = new StreamWriter(FileNameUT, true))
                {
                int count = 0;
                int Count = 0;
                for (int i = 0; i < ExistedUsers.Count; i++)
                {
                    if (textBox_Login.Text == ExistedUsers[i].Name)
                        count += 1;
                    else
                    {
                        Count += 1;
                    }
                }
                
                if(Count==ExistedUsers.Count)
                {
                    User user = new User(textBox_Login.Text, passwordBox.Password);
                    User.Add(user);
                }

                for (int i = 0; i < User.Count; i++)
                    {

                        wrPlayer.WriteLine(User[i].Info);
                    }


                }
            if ((string.IsNullOrWhiteSpace(textBox_Login.Text)) || (string.IsNullOrWhiteSpace(passwordBox.Password)))
            {
                MessageBox.Show("Enter your username and password", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
                textBox_Login.Focus();
            }
            else
            if (User.Count == 0)
            {
                MessageBox.Show("Login is existed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearData();
            }

            else
            {


                NavigationService.Navigate(RegPages.CurrentPage);




            }
            //}
            //catch
            //{
            //    //MessageBox.Show("Registration has not completed","Error");
            //}


        }

        private void button_COMPLETE_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
