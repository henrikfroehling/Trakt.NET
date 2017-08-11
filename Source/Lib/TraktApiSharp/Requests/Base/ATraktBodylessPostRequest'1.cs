namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System.Net.Http;

    internal abstract class ATraktBodylessPostRequest<TResponseContentType> : ATraktRequest<TResponseContentType>, ITraktBodylessPostRequest<TResponseContentType>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Post;
    }
}
