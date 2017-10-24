﻿using messageFilterSystem.Database;
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
        #region TextBlockContent
        public string TBlockTitle { get; private set; }
        public string TBlockMHeader { get; private set; }
        public string TBlockMID { get; private set; }
        public string TBlockMChars { get; private set; }
        public string TBlockSender { get; private set; }
        public string TBlockBody { get; private set; }
        #endregion

        #region ComboBoxContent
        public string CBoxMID { get; set; }
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

        #region Constructor
        public AddTweetViewModel()
        {
            TBlockTitle = "Add Tweet";
            TBlockMHeader = "Message Header";
            TBlockMID = "Select one of the options:";
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
            if (string.IsNullOrWhiteSpace(TBoxMID) || string.IsNullOrWhiteSpace(CBoxMID) || string.IsNullOrWhiteSpace(TBoxSender) || string.IsNullOrWhiteSpace(TBoxBody))
            {
                MessageBox.Show("Please fill out all boxes please");
                return;
            }

            MessageAdd AddMessage = new MessageAdd();

            {
                AddMessage.MessageID = CBoxMID.ToString() + TBoxMID;
                AddMessage.Sender = "@" + TBoxSender;
                AddMessage.Body = TBoxBody;
            }

            SaveToFile save = new SaveToFile();

            if (!save.WriteToCSV(AddMessage, MessageType))
            {
                MessageBox.Show("Error while saving\n" + save.ErrorCode);
            }
            else
            {
                MessageBox.Show("Order saved");
                save = null;
            }
        }
        #endregion
    }
}