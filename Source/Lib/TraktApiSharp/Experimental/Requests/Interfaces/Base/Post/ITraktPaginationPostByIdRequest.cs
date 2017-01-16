namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Post
{
    internal interface ITraktPaginationPostByIdRequest<TItem, TRequestBody> : ITraktPaginationPostRequest<TItem, TRequestBody>, ITraktHasId
    {

    }
}
