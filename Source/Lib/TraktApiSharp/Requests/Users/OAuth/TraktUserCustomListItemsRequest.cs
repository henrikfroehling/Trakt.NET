namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Extensions;
    using Interfaces;
    using Objects.Get.Users.Lists;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Users.Lists.Implementations;

    internal sealed class TraktUserCustomListItemsRequest : ATraktUsersPagedGetRequest<TraktListItem>, ITraktHasId
    {
        internal string Username { get; set; }

        public string Id { get; set; }

        internal TraktListItemType Type { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/items{/type}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);
            uriParams.Add("id", Id);

            if (Type != null && Type != TraktListItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));

            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("list id not valid", nameof(Id));
        }
    }
}
