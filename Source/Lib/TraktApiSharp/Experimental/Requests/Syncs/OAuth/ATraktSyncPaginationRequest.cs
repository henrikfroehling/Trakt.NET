namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktSyncPaginationRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktExtendedInfo
    {
        internal ATraktSyncPaginationRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
