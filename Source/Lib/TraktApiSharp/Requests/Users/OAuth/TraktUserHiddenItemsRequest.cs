namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Objects.Get.Users.Implementations;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktUserHiddenItemsRequest : ATraktUsersPagedGetRequest<TraktUserHiddenItem>
    {
        internal TraktHiddenItemsSection Section { get; set; }

        internal TraktHiddenItemType Type { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/hidden/{section}{?type,extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("section", Section.UriName);

            if (Type != null && Type != TraktHiddenItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

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
