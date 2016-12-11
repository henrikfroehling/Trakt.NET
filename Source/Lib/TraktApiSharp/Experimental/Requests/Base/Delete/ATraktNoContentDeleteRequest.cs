namespace TraktApiSharp.Experimental.Requests.Base.Delete
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentDeleteRequest : ATraktNoContentRequest
    {
        internal ATraktNoContentDeleteRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Delete;
    }
}
