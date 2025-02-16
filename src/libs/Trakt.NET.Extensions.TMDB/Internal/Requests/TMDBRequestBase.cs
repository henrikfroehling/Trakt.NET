namespace TraktNET
{
    internal abstract class TMDBRequestBase(HttpMethod method, Uri? requestUri) : HttpRequestMessage(method, requestUri)
    {
        internal abstract void BuildUri();

        internal virtual void Validate() { }
    }
}
