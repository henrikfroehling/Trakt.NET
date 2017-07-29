namespace TraktApiSharp.Requests.Users.OAuth
{
    using Enums;
    using Extensions;
    using Objects.Get.Watchlist;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktUserWatchlistRequest : ATraktUsersPagedGetRequest<ITraktWatchlistItem>
    {
        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        public override string UriTemplate => "users/{username}/watchlist{/type}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktSyncItemType.Unspecified)
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
        }
    }
}
