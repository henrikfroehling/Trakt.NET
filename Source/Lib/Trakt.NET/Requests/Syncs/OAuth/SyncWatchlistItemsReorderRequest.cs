namespace TraktNet.Requests.Syncs.OAuth
{
    using Base;
    using Objects.Post.Basic;
    using Objects.Post.Basic.Responses;
    using System.Collections.Generic;

    internal sealed class SyncWatchlistItemsReorderRequest : APostRequest<ITraktListItemsReorderPostResponse, ITraktListItemsReorderPost>
    {
        public override ITraktListItemsReorderPost RequestBody { get; set; }

        public override string UriTemplate => "sync/watchlist/reorder";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
