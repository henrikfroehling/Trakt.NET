namespace TraktApiSharp.Experimental.Requests.Base.Delete
{
    using Interfaces;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentDeleteRequest : ATraktNoContentRequest, ITraktRequest
    {
        public ATraktNoContentDeleteRequest(TraktClient client) : base(client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public HttpMethod Method => HttpMethod.Delete;
    }
}
