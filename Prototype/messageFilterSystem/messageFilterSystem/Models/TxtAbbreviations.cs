using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageFilterSystem.Models
{
    public class TxtAbbreviations
    {
        #region Variables
        public string Abbreviation { get; set; }
        public string FullWord { get; set; }
        #endregion
        #region Constructor
        public TxtAbbreviations()
        {
            Abbreviation = string.Empty;
            FullWord = string.Empty;
        }
        #endregion
    }
}
