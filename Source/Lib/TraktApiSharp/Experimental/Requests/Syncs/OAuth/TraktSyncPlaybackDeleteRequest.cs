namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Delete;

    internal sealed class TraktSyncPlaybackDeleteRequest : ATraktNoContentDeleteByIdRequest
    {
        internal TraktSyncPlaybackDeleteRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "sync/playback/{id}";
    }
}
