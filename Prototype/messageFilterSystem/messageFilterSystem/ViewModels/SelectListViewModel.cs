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
    public class SelectListViewModel : BaseViewModel
    {
        #region TextBlockContent
        public string TBlockListHeader { get; private set; }
        #endregion
        #region ButtonContent
        public string BtnTrendingListContent { get; private set; }
        public string BtnMentionListContent { get; private set; }
        public string BtnSIRListContent { get; private set; }
        #endregion
        #region ButtonCommand
        public ICommand BtnTrendingListCommand { get; private set; }
        public ICommand BtnMentionListCommand { get; private set; }
        public ICommand BtnSIRListCommand { get; private set; }
        #endregion      
        #region Constructor
        public SelectListViewModel()
        {
            TBlockTitle = "Select List to View";

            BtnSMSContent = "View SMS'";
            BtnStandardEmailContent = "View Standard Emails";
            BtnSIREmailContent = "View Incident Reports";
            BtnTweetContent = "View Tweets";

            BtnTrendingListContent = "View Trending List";
            BtnMentionListContent = "View Mentions List";
            BtnSIRListContent = "View SIR List";

            BtnSMSCommand = new RelayCommand(BtnSMSViewButtonClick);
            BtnStandardEmailCommand = new RelayCommand(BtnEMailViewButtonClick);
            BtnSIREmailCommand = new RelayCommand(BtnIncidentReportViewButtonClick);
            BtnTweetCommand = new RelayCommand(BtnTweetViewButtonClick);

            BtnTrendingListCommand = new RelayCommand(BtnTrendingListViewButtonClick);
            BtnMentionListCommand = new RelayCommand(BtnMentionListViewButtonClick);
            BtnSIRListCommand = new RelayCommand(BtnSIRListViewButtonClick);

            ContentControlBinding = new DefaultView();
        }
        #endregion
        #region ButtonControls
        private void BtnSMSViewButtonClick()
        {
            MessageType = "SMS";
            ContentControlBinding = new DisplayMessage(MessageType);
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnEMailViewButtonClick()
        {
            MessageType = "Email";
            ContentControlBinding = new DisplayEmail();
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnIncidentReportViewButtonClick()
        {
            MessageType = "SIR";
            ContentControlBinding = new DisplayEmail();
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnTweetViewButtonClick()
        {
            MessageType = "Tweet";
            ContentControlBinding = new DisplayMessage(MessageType);
            OnChanged(nameof(ContentControlBinding));
        }

        private void BtnTrendingListViewButtonClick()
        {
            ListType = "Trend";
            ContentControlBinding = new DisplayList(ListType);
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnMentionListViewButtonClick()
        {
            ListType = "Mention";
            ContentControlBinding = new DisplayList(ListType);
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnSIRListViewButtonClick()
        {
            ListType = "SIR";
            ContentControlBinding = new DisplayList(ListType);
            OnChanged(nameof(ContentControlBinding));
        }
        #endregion
    }
}
