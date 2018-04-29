namespace TraktApiSharp.Requests.Checkins.OAuth
{
    using Base;
    using Requests.Interfaces;
    using System.Collections.Generic;

    internal sealed class CheckinRequest<TResponseContentType, TRequestBodyType> : APostRequest<TResponseContentType, TRequestBodyType> where TRequestBodyType : IRequestBody
    {
        public override TRequestBodyType RequestBody { get; set; }

        public override string UriTemplate => "checkin";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}
