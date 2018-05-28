namespace TraktApiSharp.Requests.Scrobbles.OAuth
{
    using Base;
    using Requests.Interfaces;
    using System.Collections.Generic;

    internal sealed class ScrobbleStopRequest<TResponseContentType, TRequestBodyType> : APostRequest<TResponseContentType, TRequestBodyType> where TRequestBodyType : IRequestBody
    {
        public override TRequestBodyType RequestBody { get; set; }

        public override string UriTemplate => "scrobble/stop";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
