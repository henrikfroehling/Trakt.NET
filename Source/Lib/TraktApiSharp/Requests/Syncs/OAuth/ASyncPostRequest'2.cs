namespace TraktNet.Requests.Syncs.OAuth
{
    using Base;
    using Requests.Interfaces;
    using System.Collections.Generic;

    internal abstract class ASyncPostRequest<TResponseContentType, TRequestBodyType> : APostRequest<TResponseContentType, TRequestBodyType> where TRequestBodyType : IRequestBody
    {
        public override TRequestBodyType RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
