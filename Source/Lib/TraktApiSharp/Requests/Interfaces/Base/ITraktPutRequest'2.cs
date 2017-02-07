namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPutRequest<TContentType, TRequestBody> : ITraktRequest<TContentType>, ITraktHasRequestBody<TRequestBody>
    {

    }
}
