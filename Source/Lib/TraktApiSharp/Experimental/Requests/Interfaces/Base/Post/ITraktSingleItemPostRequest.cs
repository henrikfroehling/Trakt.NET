namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Post
{
    internal interface ITraktSingleItemPostRequest<TItem, TRequestBody> : ITraktSingleItemRequest<TItem>, ITraktHasRequestBody<TRequestBody>
    {

    }
}
