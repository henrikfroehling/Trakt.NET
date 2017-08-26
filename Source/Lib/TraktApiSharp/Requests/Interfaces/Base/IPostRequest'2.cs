namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IPostRequest<TResponseContentType, TRequestBodyType> : ITraktRequest<TResponseContentType>, IHasRequestBody<TRequestBodyType>
    {
    }
}
