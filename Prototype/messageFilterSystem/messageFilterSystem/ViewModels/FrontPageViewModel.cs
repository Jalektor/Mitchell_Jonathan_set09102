using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using messageFilterSystem.Commands;
using messageFilterSystem.Views;

namespace messageFilterSystem.ViewModels
{
    class FrontPageViewModel : BaseViewModel
    {
        #region TextBlockContent
        public string TBlockTitle { get; private set; }
        #endregion

        #region ButtonContent
        public string BtnSMSContent { get; private set; }
        public string BtnEmailContent { get; private set; }
        public string BtnTweetContent { get; private set; }
        public string BtnExitContent { get; private set; }
        public string BtnListDisplay { get; private set; }
        #endregion

        #region ButtonCommand
        public ICommand BtnSMSCommand { get; private set; }
        public ICommand BtnEmailCommand { get; private set; }
        public ICommand BtnTweetCommand { get; private set; }
        public ICommand BtnExitCommand { get; private set; }
        #endregion

        #region ContentControl
        public UserControl ContentControlBinding { get; private set; }
        #endregion

        #region Constructor
        public FrontPageViewModel()
        {
            TBlockTitle = "Euston Leisure Message Filtering Service";

            BtnSMSContent = "Add SMS";
            BtnEmailContent = "Add Email";
            BtnTweetContent = "Add Tweet";
            BtnExitContent = "Exit Application";
            BtnListDisplay = "Display Lists";

            BtnSMSCommand = new RelayCommand(BtnSMSButtonClick);
            BtnEmailCommand = new RelayCommand(BtnEmailButtonClick);
            BtnTweetCommand = new RelayCommand(BtnTweetButtonClick);

            ContentControlBinding = new DefaultView();
        }
        #endregion

        #region ButtonControls

        private void BtnSMSButtonClick()
        {
            ContentControlBinding = new AddSMS();
            OnChanged(nameof(ContentControlBinding));
        }

        private void BtnEmailButtonClick()
        {
            ContentControlBinding = new AddEmail();
            OnChanged(nameof(ContentControlBinding));
        }

        private void BtnTweetButtonClick()
        {
            ContentControlBinding = new AddTweet();
            OnChanged(nameof(ContentControlBinding));
        }
        #endregion

    }
}
