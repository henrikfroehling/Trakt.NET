namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Syncs.History;
    using System.Collections.Generic;

    internal class TraktSyncWatchedHistoryRequest : TraktGetRequest<TraktPaginationListResult<TraktSyncHistoryItem>, TraktSyncHistoryItem>
    {
        internal TraktSyncWatchedHistoryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        internal TraktSyncHistoryItemType? Type { get; set; }

        internal string ItemId { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "type", Type.HasValue ? Type.Value.AsString() : string.Empty },
                                                    { "id", ItemId != null ? ItemId : string.Empty } };
        }

        protected override string UriTemplate => "sync/history/{type}/{id}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
