namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Get;

    internal abstract class ATraktSyncPaginationRequest<TItem> : ATraktPaginationGetRequest<TItem>
    {
        internal ATraktSyncPaginationRequest(TraktClient client) : base(client) { }
    }
}
