namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    using Base.Post;

    internal sealed class TraktScrobbleStartRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>
    {
        internal TraktScrobbleStartRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "scrobble/start";
    }
}
