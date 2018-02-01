using System;

namespace Contoso.CRM.UITests.Forms
{
    internal class CrmFormNameAttribute : Attribute
    {
        public string Name { get; set; }

        public CrmFormNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}