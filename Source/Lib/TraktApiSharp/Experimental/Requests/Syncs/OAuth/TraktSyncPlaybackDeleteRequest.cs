namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Delete;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncPlaybackDeleteRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktSyncPlaybackDeleteRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public override string UriTemplate => "sync/playback/{id}";
    }
}
