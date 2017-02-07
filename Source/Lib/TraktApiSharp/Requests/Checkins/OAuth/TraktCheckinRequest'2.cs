namespace TraktApiSharp.Requests.Checkins.OAuth
{
    using Base;
    using System.Collections.Generic;

    internal sealed class TraktCheckinRequest<TContentType, TRequestBody> : ATraktPostRequest<TContentType, TRequestBody>
    {
        public override TRequestBody RequestBody { get; set; }

        public override string UriTemplate => "checkin";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
