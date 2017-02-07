namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktHasUri : ITraktHasUriPathParameters
    {
        string UriTemplate { get; }
    }
}
