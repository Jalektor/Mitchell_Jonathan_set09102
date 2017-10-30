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
        public ObservableCollection<TxtAbbreviations> Abbreviations { get; set; }

        public DisplayListViewModel()
        {
            LoadFromFile load = new LoadFromFile();

            if(!load.LoadTxtAbbreviations())
            {
                Abbreviations = new ObservableCollection<TxtAbbreviations>();
            }
            else
            {
                Abbreviations = new ObservableCollection<TxtAbbreviations>(load.Message);
            }
        }
    }
}
