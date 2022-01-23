namespace TraktNet.Requests.Syncs.OAuth
{
    using Enums;
    using Extensions;
    using Objects.Get.Syncs.Playback;
    using System.Collections.Generic;
    using Interfaces;
    using System;

    internal sealed class SyncPlaybackProgressRequest : ASyncGetRequest<ITraktSyncPlaybackProgressItem>, ISupportsPagination
    {
        internal TraktSyncType Type { get; set; }

        internal DateTime? StartAt { get; set; }

        internal DateTime? EndAt { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "sync/playback{/type}{?start_at,end_at,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Type != null && Type != TraktSyncType.Unspecified)
                uriParams.Add("type", Type.UriName);

            if (StartAt.HasValue)
                uriParams.Add("start_at", StartAt.Value.ToUniversalTime().ToTraktLongDateTimeString());

            if (EndAt.HasValue)
                uriParams.Add("end_at", EndAt.Value.ToUniversalTime().ToTraktLongDateTimeString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}
