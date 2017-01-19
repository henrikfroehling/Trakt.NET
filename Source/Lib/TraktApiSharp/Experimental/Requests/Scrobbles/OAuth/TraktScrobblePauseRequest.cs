namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    internal sealed class TraktScrobblePauseRequest<TItem, TRequestBody>
    {
        internal TraktScrobblePauseRequest(TraktClient client) { }

        public string UriTemplate => "scrobble/pause";
    }
}
