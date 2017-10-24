using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageFilterSystem.Models
{
    class SMSAdd
    {
        #region variables
        public string MessageID { get; set; }
        public string Sender { get; set; }
        public string Body { get; set; }
        #endregion

        #region Constructor
        public SMSAdd()
        {
            MessageID = string.Empty;
            Sender = string.Empty;
            Body = string.Empty;
        }
        #endregion
    }
}
