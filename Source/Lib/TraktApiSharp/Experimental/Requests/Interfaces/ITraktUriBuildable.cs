namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using System.Collections.Generic;

    internal interface ITraktUriBuildable
    {
        string UriTemplate { get; }

        string Url { get; }

        string BuildUrl();

        IDictionary<string, object> GetUriPathParameters();
    }
}
