﻿namespace Helpfulcore.Ste
{
	using Model.Fields.Abstractions;
	using Sitecore.Data;
	using Sitecore.Data.Fields;
	using Sitecore.Data.Items;

	public interface IFieldWrapperFactory
	{
		IFieldWrapper GetStronglyTypedField(Field field);
		TField GetStronglyTypedField<TField>(Field field) where TField : IFieldWrapper;
		IFieldWrapper GetStronglyTypedField(Item item, string fieldName);
		TField GetStronglyTypedField<TField>(Item item, string fieldName) where TField : IFieldWrapper;
		IFieldWrapper GetStronglyTypedField(Item item, ID fieldId);
		TField GetStronglyTypedField<TField>(Item item, ID fieldId) where TField : IFieldWrapper;
	}
}