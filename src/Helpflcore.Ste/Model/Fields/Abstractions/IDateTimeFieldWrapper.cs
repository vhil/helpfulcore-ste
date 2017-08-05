namespace Helpflcore.Ste.Model.Fields.Abstractions
{
    using System;
    using System.Web;

    public interface IDateTimeFieldWrapper : IFieldWrapper<DateTime>
    {
        IHtmlString Render(bool includeTime);
    }
}
