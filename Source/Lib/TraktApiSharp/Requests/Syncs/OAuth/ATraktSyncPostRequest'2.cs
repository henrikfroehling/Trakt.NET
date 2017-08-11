namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Base;
    using System.Collections.Generic;

    internal abstract class ATraktSyncPostRequest<TResponseContentType, TRequestBodyType> : ATraktPostRequest<TResponseContentType, TRequestBodyType>
    {
        public override TRequestBodyType RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
