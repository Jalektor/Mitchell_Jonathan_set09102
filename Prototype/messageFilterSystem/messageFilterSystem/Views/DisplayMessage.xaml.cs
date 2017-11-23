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
using messageFilterSystem.Models;
using System.Collections.ObjectModel;

namespace messageFilterSystem.Views
{
    /// <summary>
    /// Interaction logic for DisplayMessage.xaml
    /// </summary>
    public partial class DisplayMessage : UserControl
    {
        int i = 0;
        public List<MessageAdd> Messages { get; set; }

        public DisplayMessage(string MessageType)
        {
            InitializeComponent();
            DisplayMessageViewModel Display = new DisplayMessageViewModel(MessageType);
            this.DataContext = Display;

            Messages = Display.Messages;
        }

        private void btnNxtMsg_Click(object sender, RoutedEventArgs e)
        {
            for (int x = i; x < Messages.Count(); x++)
            {
                tBoxMID.Text = Messages[x].MessageID;
                tBoxSender.Text = Messages[x].Sender;
                tBoxBody.Text = Messages[x].Body;
                i++;
                break;
            }
        }

        private void btnPreMsg_Click(object sender, RoutedEventArgs e)
        {
            i--;
            for (int x = i; x >= 0; x++)
            {
                tBoxMID.Text = Messages[x].MessageID;
                tBoxSender.Text = Messages[x].Sender;
                tBoxBody.Text = Messages[x].Body;
                break;
            }
        }
    }
}
