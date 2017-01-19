namespace TraktApiSharp.Experimental.Requests.Scrobbles.OAuth
{
    internal sealed class TraktScrobbleStopRequest<TItem, TRequestBody>
    {
        internal TraktScrobbleStopRequest(TraktClient client) { }

        public string UriTemplate => "scrobble/stop";
    }
}
