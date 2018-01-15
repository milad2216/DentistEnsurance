using System;

namespace Web.Infra
{
    public class CustomFieldAttribute : Attribute
    {
        public string Field { get; set; }

        public CustomFieldAttribute(string Field)
        {
            this.Field = Field;
        }
    }
}