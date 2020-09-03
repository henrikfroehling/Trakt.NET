namespace TraktNet.Requests.Users.OAuth
{
    using Enums;
    using Extensions;
    using Objects.Get.Watchlist;
    using System;
    using System.Collections.Generic;

    internal sealed class UserWatchlistRequest : AUsersPagedGetRequest<ITraktWatchlistItem>
    {
        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        public TraktWatchlistSortOrder Sort { get; set; }

        public override string UriTemplate => "users/{username}/watchlist{/type}{/sort}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktSyncItemType.Unspecified)
            {
                uriParams.Add("type", Type.UriName);

                if (Sort != null && Sort != TraktWatchlistSortOrder.Unspecified)
                    uriParams.Add("sort", Sort.UriName);
            }

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
