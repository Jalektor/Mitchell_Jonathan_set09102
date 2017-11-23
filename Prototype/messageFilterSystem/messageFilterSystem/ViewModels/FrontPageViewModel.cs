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
    public class FrontPageViewModel : BaseViewModel
    {
        #region ButtonContent
        public string BtnExitContent { get; private set; }
        public string BtnListDisplay { get; private set; }
        #endregion
        #region ButtonCommand
        public ICommand BtnExitCommand { get; private set; }
        public ICommand BtnListDisplayCommand { get; private set; }
        #endregion        
        #region Constructor
        public FrontPageViewModel()
        {
            TBlockTitle = "Euston Leisure Message Filtering Service";

            BtnSMSContent = "Add SMS";
            BtnStandardEmailContent = "Add Email";
            BtnSIREmailContent = "Add Incident Report";
            BtnTweetContent = "Add Tweet";
            BtnExitContent = "Exit Application";
            BtnListDisplay = "Display Lists";

            BtnSMSCommand = new RelayCommand(BtnSMSButtonClick);
            BtnStandardEmailCommand = new RelayCommand(BtnStandardEmailButtonClick);
            BtnSIREmailCommand = new RelayCommand(BtnSIREmailButtonClick);
            BtnTweetCommand = new RelayCommand(BtnTweetButtonClick);
            BtnListDisplayCommand = new RelayCommand(BtnListDisplayClick);

            ContentControlBinding = new DefaultView();
        }
        #endregion
        #region ButtonControls
        private void BtnSMSButtonClick()
        {
            ContentControlBinding = new AddSMS();
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnStandardEmailButtonClick()
        {
            ContentControlBinding = new AddEmail();
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnSIREmailButtonClick()
        {
            ContentControlBinding = new AddSIR();
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnTweetButtonClick()
        {
            ContentControlBinding = new AddTweet();
            OnChanged(nameof(ContentControlBinding));
        }

        private void BtnListDisplayClick()
        {
            ContentControlBinding = new SelectList();
            OnChanged(nameof(ContentControlBinding));
        }
        #endregion

    }
}
