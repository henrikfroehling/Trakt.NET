namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.History;
    using System;
    using System.Collections.Generic;

    internal class TraktUserWatchedHistoryRequest : TraktGetRequest<TraktPaginationListResult<TraktHistoryItem>, TraktHistoryItem>
    {
        internal TraktUserWatchedHistoryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        internal ulong? ItemId { get; set; }

        internal DateTime? StartAt { get; set; }

        internal DateTime? EndAt { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            var isTypeSetAndValid = Type != null && Type != TraktSyncItemType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (ItemId.HasValue && ItemId.Value > 0)
                uriParams.Add("item_id", ItemId.ToString());

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

        protected override string UriTemplate => "users/{username}/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Unspecified;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
