namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPostRequest<TResponseContentType, TRequestBodyType> : ITraktRequest<TResponseContentType>, IHasRequestBody<TRequestBodyType>
    {
    }
}
