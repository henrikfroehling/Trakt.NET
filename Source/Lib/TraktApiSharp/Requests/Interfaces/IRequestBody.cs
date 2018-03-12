namespace TraktApiSharp.Requests.Interfaces
{
    using System.Net.Http;

    public interface IRequestBody : IValidatable
    {
        string HttpContentAsString { get; }

        HttpContent ToHttpContent();
    }
}
