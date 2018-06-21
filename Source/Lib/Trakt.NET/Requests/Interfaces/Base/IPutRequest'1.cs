namespace TraktNet.Requests.Interfaces.Base
{
    internal interface IPutRequest<TRequestBodyType> : IRequest, IHasRequestBody<TRequestBodyType> where TRequestBodyType : IRequestBody
    {
    }
}
