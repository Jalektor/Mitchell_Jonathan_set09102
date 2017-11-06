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
        #region Variable
        public string ListType { get; set; }
        public string MessageType { get; set; }
        #endregion
        #region TextBlockContent
        public string TBlockTitle { get; private set; }
        public string TBlockListHeader { get; private set; }
        #endregion
        #region ButtonContent
        public string BtnSMSViewContent { get; private set; }
        public string BtnStandardEmailViewContent { get; private set; }
        public string BtnIncidentReportViewContent { get; private set; }
        public string BtnTweetViewContent { get; private set; }

        public string BtnTrendingListContent { get; private set; }
        public string BtnMentionListContent { get; private set; }
        public string BtnSIRListContent { get; private set; }
        #endregion
        #region ButtonCommand
        public ICommand BtnSMSViewCommand { get; private set; }
        public ICommand BtnEmailViewCommand { get; private set; }
        public ICommand BtnIncidentReportViewCommand { get; private set; }
        public ICommand BtnTweetViewCommand { get; private set; }

        public ICommand BtnTrendingListCommand { get; private set; }
        public ICommand BtnMentionListCommand { get; private set; }
        public ICommand BtnSIRListCommand { get; private set; }
        #endregion
        #region ContentControl
        public UserControl ContentControlBinding { get; private set; }
        #endregion
        #region Constructor
        public SelectListViewModel()
        {
            TBlockTitle = "Select List to View";

            BtnSMSViewContent = "View SMS'";
            BtnStandardEmailViewContent = "View Standard Emails";
            BtnIncidentReportViewContent = "View Incident Reports";
            BtnTweetViewContent = "View Tweets";

            BtnTrendingListContent = "View Trending List";
            BtnMentionListContent = "View Mentions List";
            BtnSIRListContent = "View SIR List";

            BtnSMSViewCommand = new RelayCommand(BtnSMSViewButtonClick);
            BtnEmailViewCommand = new RelayCommand(BtnEMailViewButtonClick);
            BtnIncidentReportViewCommand = new RelayCommand(BtnIncidentReportViewButtonClick);
            BtnTweetViewCommand = new RelayCommand(BtnTweetViewButtonClick);

            BtnTrendingListCommand = new RelayCommand(BtnTrendingListViewButtonClick);
            BtnMentionListCommand = new RelayCommand(BtnMentionListViewButtonClick);
            BtnSIRListCommand = new RelayCommand(BtnSIRListViewButtonClick);

            ContentControlBinding = new DefaultView();
        }
        #endregion
        #region ButtonControls
        private void BtnSMSViewButtonClick()
        {
            ContentControlBinding = new DisplayMessage();
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnEMailViewButtonClick()
        {
            ContentControlBinding = new DisplayMessage();
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnIncidentReportViewButtonClick()
        {
            ContentControlBinding = new DisplayMessage();
            OnChanged(nameof(ContentControlBinding));
        }
        private void BtnTweetViewButtonClick()
        {
            ContentControlBinding = new DisplayMessage();
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
