namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.Syncs.Playback;
    using System.Collections.Generic;

    internal sealed class TraktSyncPlaybackProgressRequest : ATraktSyncListGetRequest<TraktSyncPlaybackProgressItem>
    {
        internal TraktSyncPlaybackProgressRequest(TraktClient client) : base(client) { }

        internal TraktSyncType Type { get; set; }

        internal int? Limit { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Type != null && Type != TraktSyncType.Unspecified)
                uriParams.Add("type", Type.UriName);

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.ToString());

            return uriParams;
        }

        public string UriTemplate => "sync/playback{/type}{?limit}";
    }
}
