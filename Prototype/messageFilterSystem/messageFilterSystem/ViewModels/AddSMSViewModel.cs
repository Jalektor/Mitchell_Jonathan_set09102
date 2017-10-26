using messageFilterSystem.Commands;
using messageFilterSystem.Database;
using messageFilterSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace messageFilterSystem.ViewModels
{
    class AddSMSViewModel
    {
        #region TextBlockContent
        public string TBlockTitle { get; private set; }
        public string TBlockMHeader { get; private set; }
        public string TBlockMID { get; private set; }        
        public string TBlockMChars { get; private set; }
        public string TBlockSender { get; private set; }
        public string TBlockBody { get; private set; }
        #endregion       

        #region textBoxContent
        public string TBoxMID { get; set;}
        public string TBoxSender { get; set; }
        public string TBoxBody { get; set; }
        #endregion

        #region ButtonContent/Command
        public string BtnInsertSMSContent { get; private set; }
        public ICommand BtnInsertSMSCommand { get; private set; }
        #endregion

        public string MessageType { get; set; }

        #region Constructor
        public AddSMSViewModel()
        {
            TBlockTitle = "Add SMS message";
            TBlockMHeader = "Message Header";
            TBlockMID = "Message Type: S";
            TBlockMChars = "Please Enter the 9 Numeric Characters:";
            TBlockSender = "Sender:";
            TBlockBody = "Body: ";

            TBoxMID = string.Empty;
            TBoxSender = string.Empty;
            TBoxBody = string.Empty;

            BtnInsertSMSContent = "Insert SMS";

            BtnInsertSMSCommand = new RelayCommand(InsertSMSClick);

            MessageType = "S";
        }
        #endregion

        #region ButtonClickFunction
        private void InsertSMSClick()
        {
            if(string.IsNullOrWhiteSpace(TBoxMID) || string.IsNullOrWhiteSpace(TBoxSender) || string.IsNullOrWhiteSpace(TBoxBody))
            {
                MessageBox.Show("Please fill out all boxes please");
                return;
            }

            MessageAdd AddMessage = new MessageAdd();

            {
                AddMessage.MessageID = "S" + TBoxMID;
                AddMessage.Sender = TBoxSender;
                AddMessage.Body = TBoxBody;
            }

            SaveToFile save = new SaveToFile();

            if (!save.WriteToCSV(AddMessage, MessageType))
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
