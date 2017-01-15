namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;

    internal abstract class ATraktUsersPaginationGetRequest<TItem> : ATraktPaginationGetRequest<TItem>
    {
        internal ATraktUsersPaginationGetRequest(TraktClient client) : base(client) {}
    }
}
