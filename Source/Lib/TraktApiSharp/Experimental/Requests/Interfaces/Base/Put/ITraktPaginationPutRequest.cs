namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Put
{
    internal interface ITraktPaginationPutRequest<TItem, TRequestBody> : ITraktPaginationRequest<TItem>, ITraktHasRequestBody<TRequestBody>
    {

    }
}
