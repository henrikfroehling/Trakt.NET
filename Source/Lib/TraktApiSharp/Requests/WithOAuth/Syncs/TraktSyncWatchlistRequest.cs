namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Watchlist;
    using System.Collections.Generic;

    internal class TraktSyncWatchlistRequest : TraktGetRequest<TraktPaginationListResult<TraktWatchlistItem>, TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktSyncItemType Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type != null && Type != TraktSyncItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "sync/watchlist{/type}{?extended,page,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
