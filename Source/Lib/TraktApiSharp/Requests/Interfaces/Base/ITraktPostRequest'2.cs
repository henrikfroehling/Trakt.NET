namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPostRequest<TContentType, TRequestBody> : ITraktRequest<TContentType>, ITraktHasRequestBody<TRequestBody>
    {

    }
}
