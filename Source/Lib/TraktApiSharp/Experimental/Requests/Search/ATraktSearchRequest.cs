namespace TraktApiSharp.Experimental.Requests.Search
{
    using Base.Get;
    using Objects.Basic;

    internal abstract class ATraktSearchRequest : ATraktPaginationGetRequest<TraktSearchResult>
    {
        public ATraktSearchRequest(TraktClient client) : base(client) { }
    }
}
