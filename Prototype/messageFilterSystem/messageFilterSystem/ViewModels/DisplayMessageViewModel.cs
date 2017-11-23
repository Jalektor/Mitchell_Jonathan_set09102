using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using messageFilterSystem.Commands;
using messageFilterSystem.Views;
using System.Windows.Input;
using messageFilterSystem.Models;
using messageFilterSystem.Database;
using System.Collections.ObjectModel;


namespace messageFilterSystem.ViewModels
{
    public class DisplayMessageViewModel : BaseViewModel
    {
        #region Variables
        public List<MessageAdd> Messages { get; set; }
        #endregion
        #region ButtonContent
        public string BtnNxtMsgContent { get; private set; }
        public string BtnPreMsgContent { get; private set; }
        #endregion
        #region Constructor
        public DisplayMessageViewModel(string MessageType)
        {
            TBlockMID = "Message ID";
            TBlockSender = "Sender:";
            TBlockBody = "Body";

            BtnNxtMsgContent = "Next Message";
            BtnPreMsgContent = "Previous Message";

            TBoxMID = "Message ID";
            TBoxSender = "Sender";
            TBoxBody = "Body";


            LoadMessageFromFile load = new LoadMessageFromFile();

            switch(MessageType)
            {
                case "SMS":
                    if(!load.LoadMessageType(MessageType))
                    {
                        Messages = new List<MessageAdd>();
                    }
                    else
                    {
                        Messages = new List<MessageAdd>(load.Message);
                    }
                    break;
                case "Tweet":
                    if (!load.LoadMessageType(MessageType))
                    {
                        Messages = new List<MessageAdd>();
                    }
                    else
                    {
                        Messages = new List<MessageAdd>(load.Message);
                    }
                    break;

            }
        }
        #endregion
        
    }
}
