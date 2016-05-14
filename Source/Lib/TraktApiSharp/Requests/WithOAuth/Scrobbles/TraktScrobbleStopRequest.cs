namespace TraktApiSharp.Requests.WithOAuth.Scrobbles
{
    using Base.Post;
    using Objects.Post;

    internal class TraktScrobbleStopRequest<TResponse, TRequest> : TraktPostRequest<TResponse, TResponse, TRequest> where TRequest : IValidatable
    {
        internal TraktScrobbleStopRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "scrobble/stop";

        protected override void Validate()
        {
            base.Validate();
            RequestBody.Validate();
        }
    }
}
