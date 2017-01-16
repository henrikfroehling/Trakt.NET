namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktUriBuildable : ITraktPathParameters
    {
        string UriTemplate { get; }

        string Url { get; }

        string BuildUrl();
    }
}
