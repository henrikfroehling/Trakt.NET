namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Post;

    internal abstract class ATraktSyncSingleItemPostRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>
    {
        internal ATraktSyncSingleItemPostRequest(TraktClient client) : base(client) { }
    }
}
