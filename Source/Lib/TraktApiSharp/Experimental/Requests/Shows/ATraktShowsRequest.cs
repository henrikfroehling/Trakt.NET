namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktShowsRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktSupportsExtendedInfo, ITraktFilterable
    {
        internal ATraktShowsRequest(TraktClient client) : base(client) { }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktCommonFilter Filter { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}
