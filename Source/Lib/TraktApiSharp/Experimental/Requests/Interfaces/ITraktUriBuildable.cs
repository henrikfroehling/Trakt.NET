namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    internal interface ITraktUriBuildable : ITraktPathParameters
    {
        string UriTemplate { get; }

        string Url { get; }

        string BuildUrl();
    }
}
