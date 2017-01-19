namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Extensions;
    using Objects.Get.History;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktUserWatchedHistoryRequest : ATraktUsersPaginationGetRequest<TraktHistoryItem>
    {
        internal TraktUserWatchedHistoryRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        internal uint? ItemId { get; set; }

        internal DateTime? StartAt { get; set; }

        internal DateTime? EndAt { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            uriParams.Add("username", Username);

            var isTypeSetAndValid = Type != null && Type != TraktSyncItemType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (isTypeSetAndValid && ItemId.HasValue && ItemId.Value > 0)
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

        public string UriTemplate => "users/{username}/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}";
    }
}
