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

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username },
                                                    { "type", Type.HasValue ? Type.Value.AsString() : string.Empty },
                                                    { "id", ItemId != null ? ItemId : string.Empty } };
        }

        protected override string UriTemplate => "users/{username}/history/{type}/{id}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
