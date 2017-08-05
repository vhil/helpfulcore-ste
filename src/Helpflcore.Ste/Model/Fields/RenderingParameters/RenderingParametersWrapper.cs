﻿namespace Helpflcore.Ste.Model.Fields.RenderingParameters
{
    using System;
    using Extensions;
    using Abstractions;
	using Sitecore.Mvc.Presentation;

	public class RenderingParametersWrapper : IRenderingParametersWrapper
    {
        private readonly RenderingParameters parameters;

        public RenderingParametersWrapper(RenderingParameters parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));

            this.parameters = parameters;
        }

        public TField GetStronglyTypedField<TField>(string fieldName) where TField : class, IRenderingParametersFieldWrapper
        {
			var rawValue = !this.parameters.Contains(fieldName) 
				? string.Empty 
				: this.parameters[fieldName];

			if (typeof(TField).IsAssignableTo(typeof(IBooleanFieldWrapper))) return new BooleanFieldWrapper(fieldName, rawValue) as TField;
            if (typeof(TField).IsAssignableTo(typeof(IIntegerFieldWrapper))) return new IntegerFieldWrapper(fieldName, rawValue) as TField;
            if (typeof(TField).IsAssignableTo(typeof(ILinkFieldWrapper))) return new LinkFieldWrapper(fieldName, rawValue) as TField;
            if (typeof(TField).IsAssignableTo(typeof(IListFieldWrapper))) return new ListFieldWrapper(fieldName, rawValue) as TField;
            if (typeof(TField).IsAssignableTo(typeof(INumberFieldWrapper))) return new NumberFieldWrapper(fieldName, rawValue) as TField;
            if (typeof(TField).IsAssignableTo(typeof(ITextFieldWrapper))) return new TextFieldWrapper(fieldName, rawValue) as TField;

            return new RenderingParametersFieldWrapper(fieldName, rawValue) as TField;
        }

        public IBooleanFieldWrapper CheckboxField(string fieldName)
        {
            return this.GetStronglyTypedField<BooleanFieldWrapper>(fieldName);
        }

        public IIntegerFieldWrapper IntegerField(string fieldName)
        {
            return this.GetStronglyTypedField<IntegerFieldWrapper>(fieldName);
        }

        public ILinkFieldWrapper LinkField(string fieldName)
        {
            return this.GetStronglyTypedField<LinkFieldWrapper>(fieldName);
        }

	    public IListFieldWrapper ListField(string fieldName)
	    {
			return this.GetStronglyTypedField<ListFieldWrapper>(fieldName);
		}

		public INumberFieldWrapper NumberField(string fieldName)
        {
            return this.GetStronglyTypedField<NumberFieldWrapper>(fieldName);
        }

        public ITextFieldWrapper TextField(string fieldName)
        {
            return this.GetStronglyTypedField<TextFieldWrapper>(fieldName);
        }
    }
}