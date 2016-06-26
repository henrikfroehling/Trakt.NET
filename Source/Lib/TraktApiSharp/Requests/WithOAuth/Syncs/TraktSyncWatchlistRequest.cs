namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Watchlist;
    using System.Collections.Generic;

    internal class TraktSyncWatchlistRequest : TraktGetRequest<TraktListResult<TraktWatchlistItem>, TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktSyncItemType? Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type.HasValue && Type != TraktSyncItemType.Unspecified)
                uriParams.Add("type", Type.Value.AsStringUriParameter());

            return uriParams;
        }

        protected override string UriTemplate => "sync/watchlist{/type}{?extended}";

        protected override bool IsListResult => true;
    }
}
