namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Watchlist;
    using System.Collections.Generic;

    internal class TraktUserWatchlistRequest : TraktGetRequest<TraktPaginationListResult<TraktWatchlistItem>, TraktWatchlistItem>
    {
        internal TraktUserWatchlistRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktSyncItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/watchlist{/type}{?extended,page,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
