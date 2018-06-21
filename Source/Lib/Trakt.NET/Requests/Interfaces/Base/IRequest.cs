namespace TraktNet.Requests.Interfaces.Base
{
    internal interface IRequest : IHttpRequest, IHasRequestAuthorization, IHasUri, IValidatable
    {
    }
}
