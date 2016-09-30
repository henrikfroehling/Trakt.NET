namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    using Base.Post;

    internal sealed class TraktScrobbleStopRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>
    {
        internal TraktScrobbleStopRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "scrobble/stop";
    }
}
