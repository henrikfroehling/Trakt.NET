namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using System.Net.Http;

    internal interface ITraktHttpRequest
    {
        HttpMethod Method { get; }
    }
}
