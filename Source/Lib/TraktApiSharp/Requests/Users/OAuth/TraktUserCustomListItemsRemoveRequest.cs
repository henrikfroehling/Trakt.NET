namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Objects.Post.Users.CustomListItems;
    using Objects.Post.Users.CustomListItems.Responses;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktUserCustomListItemsRemoveRequest : ATraktUsersPostByIdRequest<ITraktUserCustomListItemsRemovePostResponse, TraktUserCustomListItemsPost>
    {
        internal string Username { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/items/remove";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
