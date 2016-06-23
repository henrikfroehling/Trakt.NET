namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Users;
    using System;
    using System.Collections.Generic;

    internal class TraktUserWatchedHistoryRequest : TraktGetRequest<TraktPaginationListResult<TraktUserHistoryItem>, TraktUserHistoryItem>
    {
        internal TraktUserWatchedHistoryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktSyncHistoryItemType? Type { get; set; }

        internal string ItemId { get; set; }

        internal DateTime? StartAt { get; set; }

        internal DateTime? EndAt { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            var isTypeSetAndValid = Type.HasValue && Type.Value != TraktSyncHistoryItemType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.Value.AsStringUriParameter());

            if (!string.IsNullOrEmpty(ItemId) && isTypeSetAndValid)
                uriParams.Add("item_id", ItemId);

            if (StartAt.HasValue)
            {
                var startAt = StartAt.Value.ToUniversalTime();
                uriParams.Add("start_at", startAt.ToTraktLongDateTimeString());
            }

            if (EndAt.HasValue)
            {
                var endAt = EndAt.Value.ToUniversalTime();
                uriParams.Add("end_at", endAt.ToTraktLongDateTimeString());
            }

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/history{/type}{/item_id}{?start_at,end_at,page,limit}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Unspecified;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
