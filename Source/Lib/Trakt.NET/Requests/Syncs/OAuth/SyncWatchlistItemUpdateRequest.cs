namespace TraktNet.Requests.Syncs.OAuth
{
    using Base;

    internal sealed class SyncWatchlistItemUpdateRequest : AListItemUpdateRequest
    {
        public override string UriTemplate => "sync/watchlist/{list_item_id}";
    }
}
