using messageFilterSystem.Database;
using messageFilterSystem.Models;
using messageFilterSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace messageFilterSystem.ViewModels
{
    class AddTweetViewModel : BaseViewModel
    {
        List<string> Hashtag = new List<string>();
        #region ButtonContent/Command
        public string BtnInsertTweetContent { get; private set; }
        public ICommand BtnInsertTweetCommand { get; private set; }
        #endregion
        List<MessageAdd>ListMessage = new List<MessageAdd>();
        List<ListAdd> ListMention = new List<ListAdd>();
        List<ListAdd> ListHashtag = new List<ListAdd>();
        #region Constructor
        public AddTweetViewModel()
        {
            TBlockTitle = "Add Tweet";
            TBlockMHeader = "Message Header";
            TBlockMID = "Message Type: T ";
            TBlockMChars = "Please Enter the 9 Numeric Characters:";
            TBlockSender = "Twitter ID: @";
            TBlockBody = "Body: ";

            TBoxMID = string.Empty;
            TBoxSender = string.Empty;
            TBoxBody = string.Empty;

            BtnInsertTweetContent = "Insert Tweet";

            BtnInsertTweetCommand = new RelayCommand(InsertSMSClick);

            MessageType = "T";
        }
        #endregion
        #region ButtonClickFunction
        private void InsertSMSClick()
        {
            if (string.IsNullOrWhiteSpace(TBoxMID) || string.IsNullOrWhiteSpace(TBoxSender) || string.IsNullOrWhiteSpace(TBoxBody))
            {
                MessageBox.Show("Please fill out all boxes please");
                return;
            }

            MessageAdd AddMessage = new MessageAdd();

            {
                AddMessage.MessageID = "T" + TBoxMID;
                AddMessage.Sender = "@" + TBoxSender;
                AddMessage.Body = TBoxBody;
            }

            ListMessage.Add(AddMessage);

            SaveToFile File = new SaveToFile();

            if (!File.WriteToCSV(ListMessage, MessageType))
            {
                MessageBox.Show("Error while saving\n" + File.ErrorCode);
            }
            else
            {
                File = null;
            }

            ListAdd TweetMentions = new ListAdd();
            {
                TweetMentions.ListType = "@" + TBoxSender;
                TweetMentions.Count = "1";
            }

            ListType = "M";
            ListMention.Add(TweetMentions);

            SaveToList Mention = new SaveToList();

            if(!Mention.WriteToCSV(ListMention, ListType))
            {
                MessageBox.Show("Error while saving\n" + Mention.ErrorCode);
            }
            else
            {
                Mention = null;
            }

            string[] body = AddMessage.Body.Split(' ');
            foreach(string wrd in body)
            {
                if(wrd.Contains("#"))
                {
                    Hashtag.Add(wrd);
                }
            }

            if(Hashtag.Count != 0)
            {
                foreach (string Hash in Hashtag)
                {
                    ListAdd TweetHashtag = new ListAdd();
                    {
                        TweetHashtag.ListType = Hash;
                        TweetHashtag.Count = "1";
                    }

                    ListType = "H";
                    ListHashtag.Add(TweetHashtag);

                    SaveToList TweetHash = new SaveToList();

                    if (!TweetHash.WriteToCSV(ListHashtag, ListType))
                    {
                        MessageBox.Show("Error while saving\n" + TweetHash.ErrorCode);
                    }
                    else
                    {
                        TweetHash = null;
                    }
                }
            }
            MessageBox.Show("Order saved");
        }
        #endregion
    }
}
