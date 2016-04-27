namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Seasons;
    using System.Collections.Generic;

    internal class TraktSeasonCommentsRequest : TraktGetByIdSeasonRequest<TraktPaginationListResult<TraktSeasonComment>, TraktSeasonComment>
    {
        internal TraktSeasonCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder Sorting { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "sorting", Sorting.AsString() } };
        }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/comments/{sorting}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        protected override bool IsListResult => true;
    }
}
