namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;
    using System.Collections.Generic;

    internal class TraktEpisodeCommentsRequest : TraktGetByIdEpisodeRequest<TraktPaginationListResult<TraktEpisodeComment>, TraktEpisodeComment>
    {
        internal TraktEpisodeCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder Sorting { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            var parameters = new Dictionary<string, string>();

            var baseParameters = base.GetPathParameters();
            foreach (var p in baseParameters)
                parameters.Add(p.Key, p.Value);

            parameters.Add("sorting", Sorting.AsString());

            return parameters;
        }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/comments/{sorting}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
