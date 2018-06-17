namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Objects.Post.Users.HiddenItems;
    using Objects.Post.Users.HiddenItems.Responses;
    using System;
    using System.Collections.Generic;

    internal sealed class UserHiddenItemsAddRequest : APostRequest<ITraktUserHiddenItemsPostResponse, ITraktUserHiddenItemsPost>
    {
        public TraktHiddenItemsSection Section { get; set; }

        public override ITraktUserHiddenItemsPost RequestBody { get; set; }

        public override string UriTemplate => "users/hidden/{section}";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>
        {
            ["section"] = Section.UriName
        };

        public override void Validate()
        {
            base.Validate();

            if (Section == null)
                throw new ArgumentNullException(nameof(Section));

            if (Section == TraktHiddenItemsSection.Unspecified)
                throw new ArgumentException("section type must not be unspecified", nameof(Section));
        }
    }
}
