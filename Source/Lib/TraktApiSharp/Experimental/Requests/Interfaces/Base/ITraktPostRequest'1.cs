namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktPostRequest<TRequestBody> : ITraktRequest, ITraktHasRequestBody<TRequestBody>
    {

    }
}
