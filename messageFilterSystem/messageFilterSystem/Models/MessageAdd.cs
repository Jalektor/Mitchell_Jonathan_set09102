using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace messageFilterSystem.Models
{
    class MessageAdd
    {
        #region variables
        public string MessageID { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        #endregion

        #region Constructor
        public MessageAdd()
        {
            MessageID = string.Empty;
            Sender = string.Empty;
            Subject = string.Empty;
            Body = string.Empty;
        }
        #endregion
    }
}
