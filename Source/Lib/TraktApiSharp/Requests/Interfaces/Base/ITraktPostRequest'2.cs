namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPostRequest<TResponseContentType, TRequestBodyType> : ITraktRequest<TResponseContentType>, ITraktHasRequestBody<TRequestBodyType>
    {
    }
}
