namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal class TraktMovieCommentsRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktMovieComment>, TraktMovieComment>
    {
        internal TraktMovieCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder? Sorting { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Sorting.HasValue && Sorting.Value != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sorting", Sorting.Value.AsString());

            return uriParams;
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/comments{/sorting}{?page,limit}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
