namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.History;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncWatchedHistoryRequest : ATraktSyncPaginationRequest<TraktHistoryItem>
    {
        internal TraktSyncWatchedHistoryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktSyncItemType Type { get; set; }

        internal uint? ItemId { get; set; }

        internal DateTime? StartAt { get; set; }

        public override string UriTemplate => "sync/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}";
    }
}
