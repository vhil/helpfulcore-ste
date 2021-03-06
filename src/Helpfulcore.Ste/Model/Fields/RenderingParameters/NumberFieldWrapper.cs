﻿namespace Helpfulcore.Ste.Model.Fields.RenderingParameters
{
    using Abstractions;
    using System.Globalization;

	public class NumberFieldWrapper : RenderingParametersFieldWrapper, INumberFieldWrapper
    {
        private decimal? value;

        public NumberFieldWrapper(string fieldName, string value)
            : base(fieldName, value)
        {
        }

        public decimal Value
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
                if (decimal.TryParse(this.RawValue, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedValue))
                {
                    this.value = parsedValue;
                }
            }
        }
    }
}