namespace TraktNet.Requests.Syncs.OAuth
{
    using Base;
    using Objects.Get.Lists;
    using Objects.Post.Syncs.Lists;
    using System.Collections.Generic;

    internal sealed class SyncWatchlistUpdateRequest : APutRequest<ITraktList, ITraktUpdateListPost>
    {
        public override string UriTemplate => "sync/watchlist";

        public override ITraktUpdateListPost RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
