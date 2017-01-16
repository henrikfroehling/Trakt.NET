namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Post
{
    internal interface ITraktSingleItemPostByIdRequest<TItem, TRequestBody> : ITraktSingleItemPostRequest<TItem, TRequestBody>, ITraktHasId
    {

    }
}
