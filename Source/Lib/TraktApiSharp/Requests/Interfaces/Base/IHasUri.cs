namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IHasUri : ITraktHasUriPathParameters
    {
        string UriTemplate { get; }
    }
}
