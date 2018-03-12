namespace TraktApiSharp.Requests.Scrobbles.OAuth
{
    using Base;
    using Requests.Interfaces;
    using System.Collections.Generic;

    internal sealed class ScrobbleStartRequest<TResponseContentType, TRequestBodyType> : APostRequest<TResponseContentType, TRequestBodyType> where TRequestBodyType : IRequestBody
    {
        public override TRequestBodyType RequestBody { get; set; }

        public override string UriTemplate => "scrobble/start";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
