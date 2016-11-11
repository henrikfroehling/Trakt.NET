namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktShowsRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktExtendedInfo
    {
        public ATraktShowsRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
