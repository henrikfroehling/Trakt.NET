namespace TraktApiSharp.Requests.Checkins.OAuth
{
    using Base;
    using System.Collections.Generic;

    internal sealed class TraktCheckinsDeleteRequest : ATraktDeleteRequest
    {
        public override string UriTemplate => "checkin";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
