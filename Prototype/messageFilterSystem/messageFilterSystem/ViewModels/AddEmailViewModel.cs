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
    class AddEmailViewModel
    {
        #region TextBlockContent
        public string TBlockTitle { get; private set; }
        public string TBlockMHeader { get; private set; }
        public string TBlockMID { get; private set; }
        public string TBlockMChars { get; private set; }
        public string TBlockSender { get; private set; }
        public string TBlockSubject { get; private set; }
        public string TBlockBody { get; private set; }
        #endregion     

        #region textBoxContent
        public string TBoxMID { get; set; }
        public string TBoxSender { get; set; }
        public string TBoxBody { get; set; }
        public string TBoxSubject { get; set; }
        #endregion

        #region ButtonContent/Command
        public string BtnInsertSMSContent { get; private set; }
        public ICommand BtnInsertSMSCommand { get; private set; }
        #endregion

        public string MessageType { get; set; }

        #region Constructor
        public AddEmailViewModel()
        {
            TBlockTitle = "Add Email message";
            TBlockMHeader = "Message Header";
            TBlockMID = "Message Type: E";
            TBlockMChars = "Please Enter the 9 Numeric Characters:";
            TBlockSender = "Sender";
            TBlockSubject = "Subject";
            TBlockBody = "Body";

            TBoxMID = string.Empty;
            TBoxSender = string.Empty;
            TBoxBody = string.Empty;
            TBoxSubject = string.Empty;

            BtnInsertSMSContent = "Insert Email";

            BtnInsertSMSCommand = new RelayCommand(InsertSMSClick);

            MessageType = "E";
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

            EmailAdd AddEmail = new EmailAdd();
            {
                AddEmail.MessageID = "E" + TBoxMID;
                AddEmail.Sender = TBoxSender;
                AddEmail.Subject = TBoxSubject;
                AddEmail.Body = TBoxBody;
            }

            SaveToFile save = new SaveToFile();

            if (!save.EmailToCSV(AddEmail, MessageType))
            {
                MessageBox.Show("Error while saving\n" + save.ErrorCode);
            }
            else
            {
                save = null;
            }
            MessageBox.Show("Order saved");
        }
        #endregion

    }
}
