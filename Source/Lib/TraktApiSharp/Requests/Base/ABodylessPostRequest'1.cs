namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System.Net.Http;

    internal abstract class ABodylessPostRequest<TResponseContentType> : ARequest<TResponseContentType>, IBodylessPostRequest<TResponseContentType>
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Post;
    }
}
