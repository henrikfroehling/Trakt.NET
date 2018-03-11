namespace TraktApiSharp.Requests.Interfaces
{
    using System.Net.Http;

    internal interface IRequestBody : IValidatable
    {
        string HttpContentAsString { get; }

        HttpContent ToHttpContent();
    }
}
