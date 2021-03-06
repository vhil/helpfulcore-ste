﻿namespace Helpfulcore.Ste.Model.Fields.RenderingParameters
{
    using System;
    using Abstractions;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Links;

    public class LinkFieldWrapper : RenderingParametersFieldWrapper, ILinkFieldWrapper
    {
        private Item target;

        public LinkFieldWrapper(string fieldName, string value)
            : base(fieldName, value)
        {

        }

        protected virtual Item Target => this.target ?? (this.target = this.GetTarget());
        public virtual string Url => this.Target == null ? string.Empty : LinkManager.GetItemUrl(this.Target);

        public virtual Item GetTarget()
        {
            if (this.HasValue)
            {
                return Sitecore.Context.Database.GetItem(this.RawValue);
            }

            return null;
        }

        public static implicit operator string(LinkFieldWrapper field)
        {
            return field.Url;
        }

        public Guid Value => this.GetItemId(this.RawValue);

        public Guid ItemId => this.GetItemId(this.RawValue);

        public Guid GetItemId(string value)
        {
            Guid id;

            if (!Guid.TryParse(value, out id))
            {
                id = default(Guid);
            }

            return id;
        }

        public override bool HasValue => ID.IsID(this.RawValue);
    }
}