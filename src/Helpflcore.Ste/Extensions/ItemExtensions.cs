namespace Helpflcore.Ste.Extensions
{
    using Sitecore.Data.Items;
    using Model.Fields.Abstractions;

    public static class ItemExtensions
	{
        private static IStronglyTypedFieldFactory FieldFactory => StronglyTypedFieldFactory.FromConfiguration();

        public static TField StronglyTypedField<TField>(this Item item, string fieldName) where TField : IFieldWrapper
        {
            return FieldFactory.GetStronglyTypedField<TField>(item, fieldName);
        }

        public static IRichTextFieldWrapper RichTextField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<IRichTextFieldWrapper>(item, fieldName);
        }

        public static IIntegerFieldWrapper IntegerField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<IIntegerFieldWrapper>(item, fieldName);
        }

        public static INumberFieldWrapper NumberField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<INumberFieldWrapper>(item, fieldName);
        }

        public static IBooleanFieldWrapper CheckboxField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<IBooleanFieldWrapper>(item, fieldName);
        }

        public static IFileFieldWrapper FileField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<IFileFieldWrapper>(item, fieldName);
        }

        public static IDateTimeFieldWrapper DateTimeField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<IDateTimeFieldWrapper>(item, fieldName);
        }

        public static IGeneralLinkFieldWrapper GeneralLinkField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<IGeneralLinkFieldWrapper>(item, fieldName);
        }

        public static IImageFieldWrapper ImageField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<IImageFieldWrapper>(item, fieldName);
        }

        public static ILinkFieldWrapper LinkField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<ILinkFieldWrapper>(item, fieldName);
        }

        public static IListFieldWrapper ListField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<IListFieldWrapper>(item, fieldName);
        }

        public static INameValueListFieldWrapper NameValueListField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<INameValueListFieldWrapper>(item, fieldName);
        }

        public static INameLookupValueListFieldWrapper NameLookupValueField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<INameLookupValueListFieldWrapper>(item, fieldName);
        }

        public static ITextFieldWrapper TextField(this Item item, string fieldName)
        {
            return FieldFactory.GetStronglyTypedField<ITextFieldWrapper>(item, fieldName);
        }
    }
}