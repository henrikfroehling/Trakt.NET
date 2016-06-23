namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Delete;

    internal class TraktSyncPlaybackDeleteRequest : TraktDeleteByIdRequest
    {
        internal TraktSyncPlaybackDeleteRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "sync/playback/{id}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Unspecified;
    }
}
