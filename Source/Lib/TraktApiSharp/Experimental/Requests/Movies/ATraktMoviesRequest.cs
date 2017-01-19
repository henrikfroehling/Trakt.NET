namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktMoviesRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktSupportsExtendedInfo, ITraktSupportsFilter
    {
        internal ATraktMoviesRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktCommonFilter Filter { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}
