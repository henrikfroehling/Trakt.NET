namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post;

    internal class TraktScrobbleStartRequest<TResponse, TRequest> : TraktPostRequest<TResponse, TResponse, TRequest> where TRequest : IValidatable
    {
        internal TraktScrobbleStartRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/start{?extended}";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
