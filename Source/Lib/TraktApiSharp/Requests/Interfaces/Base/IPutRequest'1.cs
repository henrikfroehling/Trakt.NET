namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface IPutRequest<TRequestBodyType> : ITraktRequest, IHasRequestBody<TRequestBodyType>
    {
    }
}
