namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktRequest : IHttpRequest, IHasRequestAuthorization, IHasUri, ITraktValidatable
    {
    }
}
