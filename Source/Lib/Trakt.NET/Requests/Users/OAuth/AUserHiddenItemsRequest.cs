namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Exceptions;
    using Objects.Post.Users.HiddenItems;
    using System;
    using System.Collections.Generic;

    internal abstract class AUserHiddenItemsRequest<TResponseContentType> : APostRequest<TResponseContentType, ITraktUserHiddenItemsPost>
    {
        public TraktHiddenItemsSection Section { get; set; }

        public override ITraktUserHiddenItemsPost RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>
        {
            ["section"] = Section.UriName
        };

        public override void Validate()
        {
            base.Validate();

            if (Section == null)
                throw new TraktRequestValidationException(nameof(Section), "section must not be null");

            if (Section == TraktHiddenItemsSection.Unspecified)
                throw new TraktRequestValidationException(nameof(Section), "section type must not be unspecified");
        }
    }
}
