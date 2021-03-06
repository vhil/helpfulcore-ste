﻿namespace Helpfulcore.Ste.Model.Fields.Abstractions
{
    using System;
    using Sitecore.Data.Items;

    public interface ILinkFieldWrapper : ILinkFieldWrapper<Guid>
    {
    }

    public interface ILinkFieldWrapper<out TReturnrType> : IFieldWrapper<TReturnrType>
    {
        string Url { get; }
        Item GetTarget();
    }
}
