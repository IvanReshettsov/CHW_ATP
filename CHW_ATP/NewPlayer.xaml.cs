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
using System.Windows.Shapes;

namespace CHW_ATP
{
    /// <summary>
    /// Interaction logic for NewPlayer.xaml
    /// </summary>
    public partial class NewPlayer : Window
    {
        public NewPlayer()
        {
            InitializeComponent();
        }

        Players _newplayer;

        //public Players NewPlayer
        //{
        //    get
        //    {
        //        return _newplayer;
        //    }
        //}

        private void buttonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            
            _newplayer = new Players(textBoxNameP.Text, int.Parse(textBoxAge.Text), textBoxNationality.Text, comboBoxStrongHand.Text, int.Parse(textBoxRank.Text), int.Parse(textBoxHeight.Text), int.Parse(textBoxWeight.Text), int.Parse(textBoxTitles.Text));
            
        }
    }
}
