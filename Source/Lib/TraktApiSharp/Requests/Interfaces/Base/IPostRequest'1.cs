namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IPostRequest<TRequestBodyType> : IRequest, IHasRequestBody<TRequestBodyType> where TRequestBodyType : IRequestBody
    {
    }
}
