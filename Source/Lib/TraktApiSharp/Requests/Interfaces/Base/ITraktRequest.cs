namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktRequest : ITraktHttpRequest, IHasRequestAuthorization, IHasUri, ITraktValidatable
    {
    }
}
