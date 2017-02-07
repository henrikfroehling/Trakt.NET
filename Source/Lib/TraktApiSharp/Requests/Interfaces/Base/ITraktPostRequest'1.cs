namespace TraktApiSharp.Requests.Interfaces.Base
{
    internal interface ITraktPostRequest<TRequestBody> : ITraktRequest, ITraktHasRequestBody<TRequestBody>
    {

    }
}
