namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktMoviesRequest<TItem> : ITraktSupportsExtendedInfo, ITraktSupportsFilter
    {
        internal ATraktMoviesRequest(TraktClient client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktCommonFilter Filter { get; set; }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}
