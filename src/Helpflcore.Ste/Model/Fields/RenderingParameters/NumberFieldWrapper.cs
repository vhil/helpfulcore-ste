namespace Helpflcore.Ste.Model.Fields.RenderingParameters
{
    using Abstractions;

    public class NumberFieldWrapper : RenderingParametersFieldWrapper, INumberFieldWrapper
    {
        private float? value;

        public NumberFieldWrapper(string fieldName, string value)
            : base(fieldName, value)
        {
        }

        public float Value
        {
            get
            {
                this.InitializeValue();
                return this.value ?? 0;
            }
        }

        public override bool HasValue
        {
            get
            {
                this.InitializeValue();
                return this.value.HasValue;
            }
        }

        private void InitializeValue()
        {
            if (!this.value.HasValue)
            {
                float parsedValue;

                if (float.TryParse(this.RawValue, out parsedValue))
                {
                    this.value = parsedValue;
                }
            }
        }
    }
}