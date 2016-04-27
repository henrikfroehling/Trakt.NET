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

        internal TraktCommentSortOrder Sorting { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "sorting", Sorting.AsString() } };
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/comments/{sorting}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
