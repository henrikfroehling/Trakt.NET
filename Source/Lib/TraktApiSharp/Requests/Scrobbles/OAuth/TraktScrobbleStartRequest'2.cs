namespace TraktApiSharp.Requests.Scrobbles.OAuth
{
    using Base;
    using System.Collections.Generic;

    internal sealed class TraktScrobbleStartRequest<TContentType, TRequestBody> : ATraktPostRequest<TContentType, TRequestBody>
    {
        public override TRequestBody RequestBody { get; set; }

        public override string UriTemplate => "scrobble/start";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
