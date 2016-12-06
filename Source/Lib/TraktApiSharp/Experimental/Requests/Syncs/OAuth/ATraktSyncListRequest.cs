namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Get;

    internal abstract class ATraktSyncListRequest<TItem> : ATraktListGetRequest<TItem>
    {
        internal ATraktSyncListRequest(TraktClient client) : base(client) { }
    }
}
