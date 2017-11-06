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
    class AddTweetViewModel
    {
        List<string> Hashtag = new List<string>();
        #region TextBlockContent
        public string TBlockTitle { get; private set; }
        public string TBlockMHeader { get; private set; }
        public string TBlockMID { get; private set; }
        public string TBlockMChars { get; private set; }
        public string TBlockSender { get; private set; }
        public string TBlockBody { get; private set; }
        #endregion

        #region textBoxContent
        public string TBoxMID { get; set; }
        public string TBoxSender { get; set; }
        public string TBoxBody { get; set; }
        #endregion

        #region ButtonContent/Command
        public string BtnInsertSMSContent { get; private set; }
        public ICommand BtnInsertSMSCommand { get; private set; }
        #endregion

        public string MessageType { get; set; }
        public string ListType { get; set; }

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

            BtnInsertSMSContent = "Insert Tweet";

            BtnInsertSMSCommand = new RelayCommand(InsertSMSClick);

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

            SaveToFile File = new SaveToFile();

            if (!File.WriteToCSV(AddMessage, MessageType))
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
            SaveToList Mention = new SaveToList();

            if(!Mention.WriteToCSV(TweetMentions, ListType))
            {
                MessageBox.Show("Error while saving\n" + File.ErrorCode);
            }
            else
            {
                File = null;
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
                    SaveToList TweetHash = new SaveToList();

                    if (!TweetHash.WriteToCSV(TweetHashtag, ListType))
                    {
                        MessageBox.Show("Error while saving\n" + File.ErrorCode);
                    }
                    else
                    {
                        File = null;
                    }
                }
            }
            MessageBox.Show("Order saved");
        }
        #endregion
    }
}
