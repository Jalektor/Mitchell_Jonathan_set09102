using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messageFilterSystem.Models;
using messageFilterSystem.Database;
using System.Collections.ObjectModel;

namespace messageFilterSystem.ViewModels
{
    class DisplayListViewModel : BaseViewModel
    {
        #region Variables
        public ObservableCollection<ListAdd> Lists { get; set; }
        #endregion
        #region Constructor
        public DisplayListViewModel(string ListType)
        {
            LoadListFromFile load = new LoadListFromFile();
            if(ListType == "Trend")
            {
                if (!load.LoadListType(ListType))
                {
                    Lists = new ObservableCollection<ListAdd>();
                }
                else
                {
                    Lists = new ObservableCollection<ListAdd>(load.Message);
                }
            }
            if(ListType == "Mention")
            {
                if (!load.LoadListType(ListType))
                {
                    Lists = new ObservableCollection<ListAdd>();
                }
                else
                {
                    Lists = new ObservableCollection<ListAdd>(load.Message);
                }
            }
        }
        #endregion
    }
}
