using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageFilterSystem.Models
{
    public class EmailAdd : MessageAdd
    {
        #region Variables
        public string Subject { get; set; }
        #endregion

        #region Constructor
        public EmailAdd() : base()
        {
            Subject = string.Empty;
        }
        #endregion
    }
}
