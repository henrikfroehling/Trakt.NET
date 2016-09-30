namespace TraktApiSharp.Experimental.Requests.Search
{
    using Base.Get;
    using Enums;
    using Interfaces;
    using Objects.Basic;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktSearchRequest : ATraktPaginationGetRequest<TraktSearchResult>, ITraktExtendedInfo
    {
        public ATraktSearchRequest(TraktClient client) : base(client) { }

        public TraktExtendedOption ExtendedOption { get; set; }

        internal TraktSearchResultType ResultTypes { get; set; }
    }
}
