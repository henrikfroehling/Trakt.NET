namespace TraktApiSharp.Experimental.Requests.Interfaces.Base.Put
{
    internal interface ITraktListPutByIdRequest<TItem, TRequestBody> : ITraktListPutRequest<TItem, TRequestBody>, ITraktHasId
    {

    }
}
