namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Post
{
    internal interface ITraktPaginationPostRequest<TItem, TRequestBody> : ITraktPaginationRequest<TItem>, ITraktHasRequestBody<TRequestBody>
    {

    }
}
