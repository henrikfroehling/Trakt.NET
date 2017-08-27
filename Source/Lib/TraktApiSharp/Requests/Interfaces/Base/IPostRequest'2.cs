namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IPostRequest<TResponseContentType, TRequestBodyType> : IRequest<TResponseContentType>, IHasRequestBody<TRequestBodyType>
    {
    }
}
