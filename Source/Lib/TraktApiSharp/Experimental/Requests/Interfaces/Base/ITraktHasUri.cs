namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktHasUri : ITraktHasUriPathParameters
    {
        string UriTemplate { get; }

        string Url { get; }

        string BuildUrl();
    }
}
