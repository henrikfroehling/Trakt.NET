namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentGetRequest : ATraktNoContentRequest
    {
        internal ATraktNoContentGetRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public override HttpMethod Method => HttpMethod.Get;
    }
}
