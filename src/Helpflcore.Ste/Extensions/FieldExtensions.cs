namespace Helpflcore.Ste.Extensions
{
    using Model.Fields.Abstractions;
    using Sitecore.Data.Fields;

    public static class FieldExtensions
    {
        private static IStronglyTypedFieldFactory FieldFactory => StronglyTypedFieldFactory.FromConfiguration();

        public static TField AsStronglyTypedField<TField>(this Field field) where TField : IFieldWrapper
        {
            return FieldFactory.GetStronglyTypedField<TField>(field);
        }

        public static IRichTextFieldWrapper AsRichTextField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<IRichTextFieldWrapper>(field);
        }

        public static IIntegerFieldWrapper AsIntegerField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<IIntegerFieldWrapper>(field);
        }

        public static INumberFieldWrapper AsNumberField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<INumberFieldWrapper>(field);
        }

        public static IBooleanFieldWrapper AsCheckboxField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<IBooleanFieldWrapper>(field);
        }

        public static IFileFieldWrapper AsFileField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<IFileFieldWrapper>(field);
        }

        public static IDateTimeFieldWrapper AsDateTimeField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<IDateTimeFieldWrapper>(field);
        }

        public static IGeneralLinkFieldWrapper AsGeneralLinkField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<IGeneralLinkFieldWrapper>(field);
        }

        public static IImageFieldWrapper AsImageField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<IImageFieldWrapper>(field);
        }

        public static ILinkFieldWrapper AsLinkField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<ILinkFieldWrapper>(field);
        }

        public static IListFieldWrapper AsListField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<IListFieldWrapper>(field);
        }

        public static INameValueListFieldWrapper AsNameValueListField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<INameValueListFieldWrapper>(field);
        }

        public static INameLookupValueListFieldWrapper AsNameLookupValueField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<INameLookupValueListFieldWrapper>(field);
        }

        public static ITextFieldWrapper TextField(this Field field)
        {
            return FieldFactory.GetStronglyTypedField<ITextFieldWrapper>(field);
        }
    }
}