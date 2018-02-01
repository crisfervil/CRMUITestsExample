using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.CRM.UITests.Data
{
    class Account
    {
        public Guid? accountid { get; set; }
        public string name { get; internal set; } 
        public string address1_name { get; set; }
    }
}
