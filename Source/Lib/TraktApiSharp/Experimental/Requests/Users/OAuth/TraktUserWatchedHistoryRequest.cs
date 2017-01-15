namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.History;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserWatchedHistoryRequest : ATraktUsersPaginationGetRequest<TraktHistoryItem>
    {
        internal TraktUserWatchedHistoryRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        internal uint? ItemId { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}";
    }
}
