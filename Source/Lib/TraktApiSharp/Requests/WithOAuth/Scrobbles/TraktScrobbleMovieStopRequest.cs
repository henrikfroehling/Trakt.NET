namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post.Scrobbles;
    using Objects.Post.Scrobbles.Responses;

    internal class TraktScrobbleMovieStopRequest : TraktPostRequest<TraktMovieScrobblePostResponse, TraktMovieScrobblePostResponse, TraktMovieScrobblePost>
    {
        internal TraktScrobbleMovieStopRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/stop";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
