namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System.Net.Http;

    internal abstract class AGetRequest<TResponseContentType> : ARequest<TResponseContentType>, ITraktGetRequest<TResponseContentType>
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.NotRequired;

        public sealed override HttpMethod Method => HttpMethod.Get;
    }
}
