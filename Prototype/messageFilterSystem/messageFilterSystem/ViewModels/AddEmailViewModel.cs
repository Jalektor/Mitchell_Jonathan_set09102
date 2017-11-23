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
    class AddEmailViewModel : BaseViewModel
    {
        #region ButtonContent/Command
        public string BtnInsertEmailContent { get; private set; }
        public ICommand BtnInsertEmailCommand { get; private set; }
        #endregion
        List<EmailAdd> ListEmail = new List<EmailAdd>();
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

            BtnInsertEmailContent = "Insert Email";

            BtnInsertEmailCommand = new RelayCommand(InsertSMSClick);

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

            ListEmail.Add(AddEmail);

            SaveToFile save = new SaveToFile();

            if (!save.EmailToCSV(ListEmail, MessageType))
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
