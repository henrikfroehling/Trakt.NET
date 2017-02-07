namespace TraktApiSharp.Requests.Seasons
{
    using Enums;
    using Interfaces;
    using Objects.Basic;
    using System.Collections.Generic;

    internal sealed class TraktSeasonCommentsRequest : ATraktSeasonRequest<TraktComment>, ITraktSupportsPagination
    {
        internal TraktCommentSortOrder SortOrder { get; set; }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/comments{/sort_order}{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (SortOrder != null && SortOrder != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sort_order", SortOrder.UriName);

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}
