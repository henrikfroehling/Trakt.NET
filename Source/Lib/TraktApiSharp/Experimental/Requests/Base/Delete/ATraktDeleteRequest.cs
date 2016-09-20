namespace TraktApiSharp.Experimental.Requests.Base.Delete
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktDeleteRequest : ATraktNoContentRequest<object>
    {
        protected override HttpMethod Method => HttpMethod.Delete;

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
