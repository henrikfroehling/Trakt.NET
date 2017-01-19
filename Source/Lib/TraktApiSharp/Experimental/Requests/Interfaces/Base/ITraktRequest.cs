namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktRequest : ITraktHttpRequest, ITraktHasRequestAuthorization, ITraktHasUri, ITraktValidatable
    {

    }
}
