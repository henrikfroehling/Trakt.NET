namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPutRequest<TRequestBodyType> : ITraktRequest, IHasRequestBody<TRequestBodyType>
    {
    }
}
