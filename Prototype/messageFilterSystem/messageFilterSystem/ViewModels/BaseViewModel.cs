using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using messageFilterSystem.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace messageFilterSystem.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region TextBlockContent
        public string TBlockTitle { get; set; }
        public string TBlockMHeader { get; set; }
        public string TBlockMID { get; set; }
        public string TBlockMChars { get; set; }
        public string TBlockSender { get; set; }
        public string TBlockSubject { get; set; }
        public string TBlockBody { get; set; }
        #endregion
        #region TextBoxContent
        public string TBoxMID { get; set; }
        public string TBoxSender { get; set; }
        public string TBoxSubject { get; set; }
        public string TBoxBody { get; set; }
        #endregion
        #region ButtonContent
        public string BtnSMSContent { get; set; }
        public string BtnStandardEmailContent { get; set; }
        public string BtnSIREmailContent { get; set; }
        public string BtnTweetContent { get; set; }
        #endregion
        #region ButtonCommand
        public ICommand BtnSMSCommand { get; set; }
        public ICommand BtnStandardEmailCommand { get; set; }
        public ICommand BtnSIREmailCommand { get; set; }
        public ICommand BtnTweetCommand { get; set; }
        #endregion
        #region Variables
        public string MessageType { get; set; }
        public string ListType { get; set; }
        #endregion
        #region ContentControl
        public UserControl ContentControlBinding { get; set; }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
