namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPutRequest<TResponseContentType, TRequestBodyType> : ITraktRequest<TResponseContentType>, IHasRequestBody<TRequestBodyType>
    {
    }
}
