namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktHasUri : ITraktHasUriPathParameters
    {
        string UriTemplate { get; }
    }
}
