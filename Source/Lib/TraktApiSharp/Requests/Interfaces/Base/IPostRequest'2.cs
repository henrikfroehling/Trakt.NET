namespace TraktNet.Requests.Interfaces.Base
{
    internal interface IPostRequest<TResponseContentType, TRequestBodyType> : IRequest<TResponseContentType>, IHasRequestBody<TRequestBodyType> where TRequestBodyType : IRequestBody
    {
    }
}
