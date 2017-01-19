namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktShowsRequest<TItem> : ITraktSupportsExtendedInfo, ITraktSupportsFilter
    {
        internal ATraktShowsRequest(TraktClient client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktCommonFilter Filter { get; set; }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}
