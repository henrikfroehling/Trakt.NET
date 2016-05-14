namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post.Scrobbles;
    using Objects.Post.Scrobbles.Responses;

    internal class TraktScrobbleEpisodeStartRequest : TraktPostRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>
    {
        internal TraktScrobbleEpisodeStartRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/start";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
