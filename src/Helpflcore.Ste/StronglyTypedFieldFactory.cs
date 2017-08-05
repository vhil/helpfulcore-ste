namespace Helpflcore.Ste
{
	using System;
	using System.Data;
	using Model.Fields;
	using Model.Fields.Abstractions;
	using Sitecore.Data.Fields;
	using Sitecore.Data.Items;
	using Extensions;
	using Sitecore.Configuration;

	public class StronglyTypedFieldFactory : IStronglyTypedFieldFactory
    {
	    public static IStronglyTypedFieldFactory FromConfiguration()
	    {
		    return Factory.CreateObject("helpfulcore/stronglyTypedFieldFactory", true) as IStronglyTypedFieldFactory;
	    }

	    public IFieldWrapper GetStronglyTypedField(Field field)
        {
            if (field == null) throw new ArgumentNullException(nameof(field));

            var typeName = field.Type.Trim().ToLower();

            try
            {
                switch (typeName.ToLower())
                {
                    case "checkbox":
                        return new BooleanFieldWrapper(field);
                    case "image":
                        return new ImageFieldWrapper(field);
                    case "file":
                        return new FileFieldWrapper(field);
                    case "date":
                    case "datetime":
                        return new DateTimeFieldWrapper(field);
                    case "checklist":
                    case "treelist":
                    case "treelist with search":
                    case "treelistex":
                    case "multilist":
                    case "multilist with search":
                    case "accounts multilist":
                    case "tags":
                        return new ListFieldWrapper(field);
                    case "droplink":
                    case "droptree":
                        return new LinkFieldWrapper(field);
                    case "general link":
                    case "general link with search":
                        return new GeneralLinkFieldWrapper(field);
                    case "text":
                    case "single-line text":
                    case "multi-line text":
                        return new TextFieldWrapper(field);
                    case "rich text":
                        return new RichTextFieldWrapper(field);
                    case "number":
                        return new NumberFieldWrapper(field);
                    case "integer":
                        return new IntegerFieldWrapper(field);
                    case "name lookup value list":
                        return new NameLookupValueListFieldWrapper(field);
					case "name value list":
                        return new NameValueListFieldWrapper(field);
                    default:
                        return new TextFieldWrapper(field);
                }
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
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentNullException(nameof(fieldName));

            var field = item.Fields[fieldName.ToLower()];

            if (field == null)
            {
                throw new StrongTypingException($"Field with name '{fieldName}' can't be retrieved from item '{item.Paths.FullPath}' with ID {item.ID}.");
            }

            return this.GetStronglyTypedField(item.Fields[fieldName.ToLower()]);
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
    }
}
