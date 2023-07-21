namespace TraktNet.Requests.Syncs.OAuth
{
    using Base;

    internal sealed class SyncFavoriteItemUpdateRequest : AListItemUpdateRequest
    {
        public override string UriTemplate => "sync/favorites/{list_item_id}";
    }
}
