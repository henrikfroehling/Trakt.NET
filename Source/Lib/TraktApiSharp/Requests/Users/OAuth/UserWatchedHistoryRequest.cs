namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Extensions;
    using Interfaces;
    using Objects.Get.History;
    using System;
    using System.Collections.Generic;

    internal sealed class UserWatchedHistoryRequest : AUsersPagedGetRequest<ITraktHistoryItem>, IHasId
    {
        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        internal uint? ItemId { get; set; }

        internal DateTime? StartAt { get; set; }

        internal DateTime? EndAt { get; set; }

        public string Id { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Object;

        public override string UriTemplate => "users/{username}/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            var isTypeSetAndValid = Type != null && Type != TraktSyncItemType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (isTypeSetAndValid && ItemId.HasValue && ItemId.Value > 0)
            {
                var strItemId = ItemId.ToString();
                uriParams.Add("item_id", strItemId);
                Id = strItemId;
            }

            if (StartAt.HasValue)
                uriParams.Add("start_at", StartAt.Value.ToTraktLongDateTimeString());

            if (EndAt.HasValue)
                uriParams.Add("end_at", EndAt.Value.ToTraktLongDateTimeString());

            return uriParams;
        }

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
