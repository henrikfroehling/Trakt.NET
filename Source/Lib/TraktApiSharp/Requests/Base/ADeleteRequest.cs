namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System.Net.Http;

    internal abstract class ADeleteRequest : ARequest, IDeleteRequest
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Delete;
    }
}
