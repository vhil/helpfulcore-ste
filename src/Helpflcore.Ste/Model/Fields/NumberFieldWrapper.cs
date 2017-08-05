namespace Helpflcore.Ste.Model.Fields
{
    using Abstractions;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;

    public class NumberFieldWrapper : FieldWrapper, INumberFieldWrapper
    {
        private float? value;

        public NumberFieldWrapper(Field originalField) 
            : base(originalField)
        {
        }

        public NumberFieldWrapper(BaseItem item, string fieldName) 
            : base(item, fieldName)
        {
        }

        public override bool HasValue
        {
            get
            {
                this.InitializeValue();
                return this.value.HasValue;
            }
        }

        public float Value
        {
            get
            {
                this.InitializeValue();
                return this.value ?? 0;
            }
        }

        protected void InitializeValue()
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