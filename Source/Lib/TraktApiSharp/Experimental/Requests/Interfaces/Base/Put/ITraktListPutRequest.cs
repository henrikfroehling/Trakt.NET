namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Put
{
    internal interface ITraktListPutRequest<TItem, TRequestBody> : ITraktListRequest<TItem>, ITraktHasRequestBody<TRequestBody>
    {

    }
}
