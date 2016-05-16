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

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type.HasValue && Type != TraktSyncHistoryItemType.Unspecified)
                uriParams.Add("type", Type.Value.AsString());

            if (!string.IsNullOrEmpty(ItemId))
                uriParams.Add("item_id", ItemId);

            return uriParams;
        }

        protected override string UriTemplate => "sync/history/{type}/{item_id}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
