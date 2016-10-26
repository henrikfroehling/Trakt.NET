namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktMoviesRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktExtendedInfo
    {
        internal ATraktMoviesRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
