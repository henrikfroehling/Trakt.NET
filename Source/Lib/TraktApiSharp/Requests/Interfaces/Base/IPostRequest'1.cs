namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IPostRequest<TRequestBodyType> : ITraktRequest, IHasRequestBody<TRequestBodyType>
    {
    }
}
