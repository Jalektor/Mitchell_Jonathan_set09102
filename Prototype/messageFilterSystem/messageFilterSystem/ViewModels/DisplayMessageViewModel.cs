using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using messageFilterSystem.Commands;
using messageFilterSystem.Views;
using System.Windows.Input;


namespace messageFilterSystem.ViewModels
{
    public class DisplayMessageViewModel
    {
        #region textBlockContent
        public string TBlockMID { get; private set; }
        public string TBlockSender { get; private set;}
        public string TBlockBody { get; private set; }
        #endregion
        #region ButtonContent
        public string BtnNxtMsgContent { get; private set; }
        public string BtnPreMsgContent { get; private set; }
        #endregion
        #region Constructor
        public DisplayMessageViewModel()
        {
            TBlockMID = "Message ID";
            TBlockSender = "Sender:";
            TBlockBody = "Body";

            BtnNxtMsgContent = "Next Message";
            BtnPreMsgContent = "Previous Message";
        }
        #endregion
    }
}
