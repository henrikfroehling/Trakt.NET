namespace TraktNET
{
    internal abstract class RequestBase(HttpMethod method, Uri? requestUri) : HttpRequestMessage(method, requestUri)
    {
        internal abstract void BuildUri();
    }
}
