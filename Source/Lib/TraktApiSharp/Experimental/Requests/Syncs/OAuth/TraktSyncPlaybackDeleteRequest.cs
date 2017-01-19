namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncPlaybackDeleteRequest
    {
        internal TraktSyncPlaybackDeleteRequest(TraktClient client) { }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public string UriTemplate => "sync/playback/{id}";
    }
}
