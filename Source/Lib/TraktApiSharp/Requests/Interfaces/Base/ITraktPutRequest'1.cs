namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPutRequest<TRequestBody> : ITraktRequest, ITraktHasRequestBody<TRequestBody>
    {

    }
}
