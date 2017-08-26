namespace TraktApiSharp.Requests.Checkins.OAuth
{
    using Base;
    using System.Collections.Generic;

    internal sealed class TraktCheckinRequest<TResponseContentType, TRequestBodyType> : APostRequest<TResponseContentType, TRequestBodyType>
    {
        public override TRequestBodyType RequestBody { get; set; }

        public override string UriTemplate => "checkin";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
