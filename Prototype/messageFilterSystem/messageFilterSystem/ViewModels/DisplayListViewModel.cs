using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messageFilterSystem.Models;
using messageFilterSystem.Database;
using System.Collections.ObjectModel;
using System.Windows;

namespace messageFilterSystem.ViewModels
{
    class DisplayListViewModel
    {
        #region Variables
        public List<ListAdd> Lists { get; set; }
        #endregion
        #region ListHeaders
        #endregion
        #region Constructor
        public DisplayListViewModel(string ListType)
        {
            
            LoadListFromFile load = new LoadListFromFile();

            if(ListType == "Trend")
            {
                if (!load.LoadListType(ListType))
                {
                    Lists = new List<ListAdd>();
                }
                else
                {
                    Lists = new List<ListAdd>(load.Message);
                }
            }
            if(ListType == "Mention")
            {
                if (!load.LoadListType(ListType))
                {
                    Lists = new List<ListAdd>();
                }
                else
                {
                    Lists = new List<ListAdd>(load.Message);
                }
            }
            if (ListType == "SIR")
            {
                if (!load.LoadListType(ListType))
                {
                    Lists = new List<ListAdd>();
                }
                else
                {
                    Lists = new List<ListAdd>(load.Message);
                }
            }
        }
        #endregion
    }
}
