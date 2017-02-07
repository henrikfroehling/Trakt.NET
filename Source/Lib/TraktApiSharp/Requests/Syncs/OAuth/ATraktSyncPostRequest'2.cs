namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Base;
    using System.Collections.Generic;

    internal abstract class ATraktSyncPostRequest<TContentType, TRequestBody> : ATraktPostRequest<TContentType, TRequestBody>
    {
        public override TRequestBody RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
