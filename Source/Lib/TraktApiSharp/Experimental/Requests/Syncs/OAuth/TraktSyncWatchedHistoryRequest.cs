namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.History;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncWatchedHistoryRequest : ATraktSyncPaginationRequest<TraktHistoryItem>
    {
        internal TraktSyncWatchedHistoryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "sync/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}";
    }
}
