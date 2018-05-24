namespace Helpfulcore.Ste.Model.Fields.RenderingParameters
{
    using System;
    using Abstractions;

    public class CheckboxFieldWrapper : RenderingParametersFieldWrapper, ICheckboxFieldWrapper
    {
        public bool Value => !string.IsNullOrWhiteSpace(this.RawValue) && this.RawValue.Equals("1");

        public CheckboxFieldWrapper(string fieldName, string value)
            : base(fieldName, value)
        {
        }

        public static implicit operator bool(CheckboxFieldWrapper field)
        {
            return field.Value;
        }

        public static implicit operator string(CheckboxFieldWrapper field)
        {
            return field.Value.ToString();
        }

        public static implicit operator int(CheckboxFieldWrapper field)
        {
            return Convert.ToInt32(field.Value);
        }
    }
}