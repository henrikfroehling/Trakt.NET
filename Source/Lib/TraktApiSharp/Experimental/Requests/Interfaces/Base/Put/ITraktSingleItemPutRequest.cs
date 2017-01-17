namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Put
{
    internal interface ITraktSingleItemPutRequest<TItem, TRequestBody> : ITraktSingleItemRequest<TItem>, ITraktHasRequestBody<TRequestBody>
    {

    }
}
