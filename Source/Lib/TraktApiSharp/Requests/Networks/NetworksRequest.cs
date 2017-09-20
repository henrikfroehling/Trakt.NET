namespace TraktApiSharp.Requests.Networks
{
    using Base;
    using Objects.Basic;
    using System.Collections.Generic;

    internal sealed class NetworksRequest : AGetRequest<ITraktNetwork>
    {
        public override string UriTemplate => "networks";

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();

        public override void Validate() { }
    }
}
