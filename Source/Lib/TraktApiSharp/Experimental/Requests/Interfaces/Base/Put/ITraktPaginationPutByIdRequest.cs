namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Put
{
    internal interface ITraktPaginationPutByIdRequest<TItem, TRequestBody> : ITraktPaginationPutRequest<TItem, TRequestBody>, ITraktHasId
    {

    }
}
