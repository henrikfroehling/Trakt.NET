namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Put
{
    internal interface ITraktSingleItemPutByIdRequest<TItem, TRequestBody> : ITraktSingleItemPutRequest<TItem, TRequestBody>, ITraktHasId
    {

    }
}
