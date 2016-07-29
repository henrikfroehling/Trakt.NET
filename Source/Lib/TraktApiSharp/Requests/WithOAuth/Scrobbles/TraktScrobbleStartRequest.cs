namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post.Scrobbles;

    internal class TraktScrobbleStartRequest<TResponse, TRequest> : TraktPostRequest<TResponse, TResponse, TRequest> where TRequest : TraktScrobblePost
    {
        internal TraktScrobbleStartRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/start{?extended}";
    }
}
