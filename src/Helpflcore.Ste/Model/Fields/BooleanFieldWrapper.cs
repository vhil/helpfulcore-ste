namespace Helpflcore.Ste.Model.Fields
{
    using System;
    using Abstractions;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;

    public class BooleanFieldWrapper : FieldWrapper, IBooleanFieldWrapper
    {
        public BooleanFieldWrapper(Field originalField) 
            : base(originalField)
        {
        }

        public BooleanFieldWrapper(BaseItem item, string fieldName) 
            : base(item, fieldName)
        {
        }

        public bool Value => this.OriginalField.Value == "1";

        public static implicit operator bool(BooleanFieldWrapper field)
        {
            return field.Value;
        }

        public static implicit operator string(BooleanFieldWrapper field)
        {
            return field.Value.ToString();
        }

        public static implicit operator int(BooleanFieldWrapper field)
        {
            return Convert.ToInt32(field.Value);
        }
    }
}
