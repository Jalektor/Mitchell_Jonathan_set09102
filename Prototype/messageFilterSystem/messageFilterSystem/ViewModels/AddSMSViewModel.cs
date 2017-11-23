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
    class AddSMSViewModel : BaseViewModel
    {
        #region ButtonContent/Command
        public string BtnInsertSMSContent { get; private set; }
        public ICommand BtnInsertSMSCommand { get; private set; }
        #endregion
        List<MessageAdd> ListMessage = new List<MessageAdd>();

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

            ListMessage.Add(AddMessage);

            SaveToFile save = new SaveToFile();

            if (!save.WriteToCSV(ListMessage, MessageType))
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
