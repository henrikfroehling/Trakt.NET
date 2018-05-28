namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IPutRequest<TResponseContentType, TRequestBodyType> : IRequest<TResponseContentType>, IHasRequestBody<TRequestBodyType> where TRequestBodyType : IRequestBody
    {
    }
}
