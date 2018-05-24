namespace Helpfulcore.Ste
{
	using System;
	using System.Data;
	using Model.Fields;
	using Model.Fields.Abstractions;
	using Sitecore.Data.Fields;
	using Sitecore.Data.Items;
	using Extensions;
	using Sitecore.Configuration;
	using Pipelines;
	using Sitecore.Data;
	using Sitecore.Pipelines;

	public class StronglyTypedFieldFactory : IStronglyTypedFieldFactory
    {
	    public static IStronglyTypedFieldFactory Instance()
	    {
		    return Factory.CreateObject("helpfulcore/stronglyTypedFieldFactory", true) as IStronglyTypedFieldFactory;
	    }

	    public IFieldWrapper GetStronglyTypedField(Field field)
        {
            if (field == null) throw new ArgumentNullException(nameof(field));

            try
            {
	            var wrapFieldAgrs = new WrapFieldArgs(field);
	            CorePipeline.Run("ste.wrapField", wrapFieldAgrs);

				return wrapFieldAgrs.FieldWrapper ?? new TextFieldWrapper(field);
            }
            catch (Exception ex)
            {
                throw new StrongTypingException($"StronglyTypedFieldFactory: field '{field.Name}' of '{field.Type}' could not be wrapped into strongly typed field wrapper.", ex);
            }
        }

        public TField GetStronglyTypedField<TField>(Field field) where TField : IFieldWrapper
        {
            var stronglyTypedField = this.GetStronglyTypedField(field);
            if (stronglyTypedField.GetType().IsAssignableTo(typeof(TField)))
            {
                return (TField) stronglyTypedField;
            }

            throw new StrongTypingException($"Field wrapper of type '{stronglyTypedField.GetType().Name}' can't be casted to target field wrapper '{typeof(TField).Name}'. Field '{field.Name}' of '{field.Type}'. Make sure you are calling correct type for give field.");
        }

        public IFieldWrapper GetStronglyTypedField(Item item, string fieldName)
        {
	        return this.GetStronglyTypedField<IFieldWrapper>(item, fieldName);
        }

        public TField GetStronglyTypedField<TField>(Item item, string fieldName) where TField : IFieldWrapper
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentNullException(nameof(fieldName));

            var field = item.Fields[fieldName.ToLower()];

            if (field == null)
            {
                throw new StrongTypingException($"Field with name '{fieldName}' can't be retrieved from item '{item.Paths.FullPath}' with ID {item.ID}.");
            }

            return this.GetStronglyTypedField<TField>(field);
        }

	    public IFieldWrapper GetStronglyTypedField(Item item, ID fieldId)
	    {
			return this.GetStronglyTypedField<IFieldWrapper>(item, fieldId);

		}

		public TField GetStronglyTypedField<TField>(Item item, ID fieldId) where TField : IFieldWrapper
	    {
			if (item == null) throw new ArgumentNullException(nameof(item));
		    if (ID.IsNullOrEmpty(fieldId)) throw new ArgumentNullException(nameof(fieldId));

		    var field = item.Fields[fieldId];

		    if (field == null)
		    {
			    throw new StrongTypingException($"Field with ID '{fieldId}' can't be retrieved from item '{item.Paths.FullPath}' with ID {item.ID}.");
		    }

		    return this.GetStronglyTypedField<TField>(field);
		}
    }
}
