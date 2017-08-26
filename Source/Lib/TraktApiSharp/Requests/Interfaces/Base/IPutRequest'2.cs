namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IPutRequest<TResponseContentType, TRequestBodyType> : ITraktRequest<TResponseContentType>, IHasRequestBody<TRequestBodyType>
    {
    }
}
