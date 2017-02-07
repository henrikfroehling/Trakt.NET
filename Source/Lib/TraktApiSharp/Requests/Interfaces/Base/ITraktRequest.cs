namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktRequest : ITraktHttpRequest, ITraktHasRequestAuthorization, ITraktHasUri, ITraktValidatable
    {

    }
}
