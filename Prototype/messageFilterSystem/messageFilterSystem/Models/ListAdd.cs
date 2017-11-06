using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageFilterSystem.Models
{
    public class ListAdd
    {
        #region Variable
        public string ListType { get; set; }
        public string Count { get; set; }
        #endregion
        #region Constructor
        public ListAdd()
        {
            ListType = string.Empty;
            Count = string.Empty;
        }
        #endregion

    }
}
