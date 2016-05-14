namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post.Scrobbles;
    using Objects.Post.Scrobbles.Responses;

    internal class TraktScrobbleEpisodeStopRequest : TraktPostRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>
    {
        internal TraktScrobbleEpisodeStopRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/stop";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
