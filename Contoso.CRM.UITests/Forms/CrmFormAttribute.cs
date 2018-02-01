using System;

namespace Contoso.CRM.UITests.Forms
{
    internal class CrmFormAttribute : Attribute
    {
        public string FormName { get; set; }
        public string EntityName { get; set; }

        public CrmFormAttribute()
        {
        }
    }
}