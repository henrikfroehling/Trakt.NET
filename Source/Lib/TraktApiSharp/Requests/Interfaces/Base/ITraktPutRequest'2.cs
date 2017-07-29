namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPutRequest<TResponseContentType, TRequestBodyType> : ITraktRequest<TResponseContentType>, ITraktHasRequestBody<TRequestBodyType>
    {

    }
}
