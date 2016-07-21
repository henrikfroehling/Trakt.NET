namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post.Scrobbles;

    internal class TraktScrobblePauseRequest<TResponse, TRequest> : TraktPostRequest<TResponse, TResponse, TRequest> where TRequest : TraktScrobblePost
    {
        internal TraktScrobblePauseRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/pause{?extended}";
    }
}
