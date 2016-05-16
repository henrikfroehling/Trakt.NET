namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserWatchedHistoryRequest : TraktGetRequest<TraktPaginationListResult<TraktUserHistoryItem>, TraktUserHistoryItem>
    {
        internal TraktUserWatchedHistoryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktSyncHistoryItemType? Type { get; set; }

        internal string ItemId { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type.HasValue && Type.Value != TraktSyncHistoryItemType.Unspecified)
                uriParams.Add("type", Type.Value.AsStringUriParameter());

            if (!string.IsNullOrEmpty(ItemId))
                uriParams.Add("item_id", ItemId);

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/history/{type}/{item_id}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
