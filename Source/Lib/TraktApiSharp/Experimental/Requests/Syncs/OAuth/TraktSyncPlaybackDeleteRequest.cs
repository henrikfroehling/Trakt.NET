namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Delete;
    using Interfaces;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncPlaybackDeleteRequest : ATraktNoContentDeleteByIdRequest, ITraktObjectRequest
    {
        internal TraktSyncPlaybackDeleteRequest(TraktClient client) : base(client) { }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public override string UriTemplate => "sync/playback/{id}";
    }
}
