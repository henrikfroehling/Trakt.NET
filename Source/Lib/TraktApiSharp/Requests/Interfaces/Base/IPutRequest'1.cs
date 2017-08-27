namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IPutRequest<TRequestBodyType> : IRequest, IHasRequestBody<TRequestBodyType>
    {
    }
}
