namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Post
{
    internal interface ITraktListPostRequest<TItem, TRequestBody> : ITraktListRequest<TItem>, ITraktHasRequestBody<TRequestBody>
    {

    }
}
