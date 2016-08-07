namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktShowCommentsRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktComment>, TraktComment>
    {
        internal TraktShowCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder Sorting { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Sorting != null && Sorting != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sorting", Sorting.UriName);

            return uriParams;
        }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/comments{/sorting}{?page,limit}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}
