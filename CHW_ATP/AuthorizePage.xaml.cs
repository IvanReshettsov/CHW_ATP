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

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for AuthorizePage.xaml
    /// </summary>
    public partial class AuthorizePage : Page
    {
        List<User> User = new List<User>();
        const string FileNameUT = "../../users.txt";


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
                    countLGerrors+=1;
            }
            if (countLGerrors == User.Count)
            {
                MessageBox.Show("Incorrect login");
                ClearData();
                
                    }
            if ((countPWerrors != 0)&&(countSuccess==0))
            {
                MessageBox.Show("Incorrect password");
                passwordBox.Clear();
                passwordBox.Focus();
            }
            
        }
        //private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    // Using keyboard handling on the page level
        //    if (e.Key == Key.Enter)
        //        button_register_Click(null, null);
        //}







    }
}

