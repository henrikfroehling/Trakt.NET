namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktMovieCommentsRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktComment>, TraktComment>
    {
        internal TraktMovieCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder Sorting { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Sorting != null && Sorting != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sorting", Sorting.UriName);

            return uriParams;
        }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/comments{/sorting}{?page,limit}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
