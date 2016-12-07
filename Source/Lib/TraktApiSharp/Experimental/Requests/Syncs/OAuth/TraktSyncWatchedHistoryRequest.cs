namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.History;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncWatchedHistoryRequest : ATraktSyncPaginationRequest<TraktHistoryItem>
    {
        internal TraktSyncWatchedHistoryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktSyncItemType Type { get; set; }

        internal uint? ItemId { get; set; }

        internal DateTime? StartAt { get; set; }

        internal DateTime? EndAt { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override string UriTemplate => "sync/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}";
    }
}
