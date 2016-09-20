namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using System.Net.Http;

    internal interface ITraktHttpRequest
    {
        HttpMethod Method { get; }
    }
}
