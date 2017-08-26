namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System.Net.Http;

    internal abstract class AGetRequest<TResponseContentType> : ATraktRequest<TResponseContentType>, ITraktGetRequest<TResponseContentType>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public sealed override HttpMethod Method => HttpMethod.Get;
    }
}
