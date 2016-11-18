namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Enums;
    using Interfaces;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowCommentsRequest : ATraktPaginationGetByIdRequest<TraktComment>, ITraktObjectRequest
    {
        public TraktShowCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder Sorting { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/comments{/sorting}{?page,limit}";
    }
}
