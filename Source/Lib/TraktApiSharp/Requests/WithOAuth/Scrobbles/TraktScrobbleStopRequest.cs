namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post.Scrobbles;

    internal class TraktScrobbleStopRequest<TResponse, TRequest> : TraktPostRequest<TResponse, TResponse, TRequest> where TRequest : TraktScrobblePost
    {
        internal TraktScrobbleStopRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/stop{?extended}";
    }
}
