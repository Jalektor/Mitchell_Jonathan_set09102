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
using messageFilterSystem.ViewModels;

namespace messageFilterSystem.Views
{
    /// <summary>
    /// Interaction logic for AddTweet.xaml
    /// </summary>
    public partial class AddTweet : UserControl
    {
        private int count = 240;
        public AddTweet()
        {
            InitializeComponent();

            this.DataContext = new AddTweetViewModel();
            tBlockCharCount.Text = "Total chars Remaining: " + count.ToString();
        }

        private void tBoxBody_TextChanged(object sender, TextChangedEventArgs e)
        {
            count--;
            tBlockCharCount.Text = "Total chars Remaining: " + count.ToString();

        }
    }
}
