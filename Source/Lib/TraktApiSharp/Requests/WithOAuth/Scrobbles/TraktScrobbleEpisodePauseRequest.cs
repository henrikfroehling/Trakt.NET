namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post.Scrobbles;
    using Objects.Post.Scrobbles.Responses;

    internal class TraktScrobbleEpisodePauseRequest : TraktPostRequest<TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePostResponse, TraktEpisodeScrobblePost>
    {
        internal TraktScrobbleEpisodePauseRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/pause";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
