namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktRequest : ITraktHttpRequest, ITraktHasRequestAuthorization, ITraktUriBuildable
    {
        TraktClient Client { get; }
    }
}
