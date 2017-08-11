namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPostRequest<TRequestBodyType> : ITraktRequest, ITraktHasRequestBody<TRequestBodyType>
    {
    }
}
