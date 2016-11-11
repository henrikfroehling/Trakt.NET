namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;

    internal abstract class ATraktShowsRequest<TItem> : ATraktPaginationGetRequest<TItem>
    {
        public ATraktShowsRequest(TraktClient client) : base(client) { }
    }
}
