﻿namespace Helpfulcore.Ste.Model.Fields.RenderingParameters
{
    using Abstractions;

    public class IntegerFieldWrapper : RenderingParametersFieldWrapper, IIntegerFieldWrapper
    {
        private int? value;

        public IntegerFieldWrapper(string fieldName, string value)
            : base(fieldName, value)
        {
        }

        public int Value
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
                int parsedValue;

                if (int.TryParse(this.RawValue, out parsedValue))
                {
                    this.value = parsedValue;
                }
            }
        }
    }
}