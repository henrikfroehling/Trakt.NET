namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    using System.Net.Http;

    internal interface ITraktHttpRequest
    {
        HttpMethod Method { get; }
    }
}
