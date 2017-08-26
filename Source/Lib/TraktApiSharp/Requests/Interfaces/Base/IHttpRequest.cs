namespace TraktApiSharp.Requests.Interfaces.Base
{
    using System.Net.Http;

    internal interface IHttpRequest
    {
        HttpMethod Method { get; }
    }
}
