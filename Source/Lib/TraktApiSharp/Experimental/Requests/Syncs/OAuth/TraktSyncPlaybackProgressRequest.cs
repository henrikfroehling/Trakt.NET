namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.Syncs.Playback;
    using System.Collections.Generic;

    internal sealed class TraktSyncPlaybackProgressRequest : ATraktSyncListRequest<TraktSyncPlaybackProgressItem>
    {
        internal TraktSyncPlaybackProgressRequest(TraktClient client) : base(client) { }

        internal TraktSyncType Type { get; set; }

        internal int? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type != null && Type != TraktSyncType.Unspecified)
                uriParams.Add("type", Type.UriName);

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.ToString());

            return uriParams;
        }

        public override string UriTemplate => "sync/playback{/type}{?limit}";
    }
}
