namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Seasons;
    using System.Collections.Generic;

    internal class TraktSeasonCommentsRequest : TraktGetByIdSeasonRequest<TraktPaginationListResult<TraktSeasonComment>, TraktSeasonComment>
    {
        internal TraktSeasonCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder? Sorting { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Sorting.HasValue && Sorting.Value != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sorting", Sorting.Value.AsString());

            return uriParams;
        }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/comments{/sorting}{?page,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
