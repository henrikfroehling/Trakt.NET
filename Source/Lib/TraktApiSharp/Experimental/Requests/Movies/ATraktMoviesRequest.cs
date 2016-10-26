namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;

    internal abstract class ATraktMoviesRequest<TItem> : ATraktPaginationGetRequest<TItem>
    {
        internal ATraktMoviesRequest(TraktClient client) : base(client) { }
    }
}
