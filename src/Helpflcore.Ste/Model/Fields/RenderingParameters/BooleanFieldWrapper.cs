namespace Helpflcore.Ste.Model.Fields.RenderingParameters
{
    using System;
    using Abstractions;

    public class BooleanFieldWrapper : RenderingParametersFieldWrapper, IBooleanFieldWrapper
    {
        public bool Value => !string.IsNullOrWhiteSpace(this.RawValue) && this.RawValue.Equals("1");

        public BooleanFieldWrapper(string fieldName, string value)
            : base(fieldName, value)
        {
        }

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