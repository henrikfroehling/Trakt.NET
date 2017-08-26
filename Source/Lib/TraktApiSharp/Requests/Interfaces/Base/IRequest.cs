namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IRequest : IHttpRequest, IHasRequestAuthorization, IHasUri, ITraktValidatable
    {
    }
}
