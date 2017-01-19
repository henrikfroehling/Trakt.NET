namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    internal sealed class TraktScrobbleStartRequest<TItem, TRequestBody>
    {
        internal TraktScrobbleStartRequest(TraktClient client) { }

        public string UriTemplate => "scrobble/start";
    }
}
