namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System.Net.Http;

    internal abstract class ADeleteRequest : ARequest, ITraktDeleteRequest
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Delete;
    }
}
