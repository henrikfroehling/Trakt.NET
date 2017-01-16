namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Post
{
    internal interface ITraktListPostByIdRequest<TItem, TRequestBody> : ITraktListPostRequest<TItem, TRequestBody>, ITraktHasId
    {

    }
}
