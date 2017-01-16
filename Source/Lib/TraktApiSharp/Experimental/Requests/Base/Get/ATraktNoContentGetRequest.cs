namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces.Base.Get;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentGetRequest : ATraktNoContentRequest, ITraktNoContentGetRequest
    {
        internal ATraktNoContentGetRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public override HttpMethod Method => HttpMethod.Get;
    }
}
