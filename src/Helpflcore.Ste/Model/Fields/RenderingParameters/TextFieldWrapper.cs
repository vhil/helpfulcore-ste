namespace Helpfulcore.Ste.Model.Fields.RenderingParameters
{
    using Abstractions;

    public class TextFieldWrapper : RenderingParametersFieldWrapper, ITextFieldWrapper
    {
        public TextFieldWrapper(string fieldName, string value)
            : base(fieldName, value)
        {
        }

        public string Value => this.RawValue;
    }
}