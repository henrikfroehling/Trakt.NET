namespace TraktNet.Requests.Episodes
{
    using Enums;
    using Interfaces;
    using Objects.Basic;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class EpisodeCommentsRequest : AEpisodeRequest<ITraktComment>, ISupportsPagination
    {
        internal TraktExtendedCommentSortOrder SortOrder { get; set; }

        internal TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/comments{/sort_order}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (SortOrder != null && SortOrder != TraktExtendedCommentSortOrder.Unspecified)
                uriParams.Add("sort_order", SortOrder.UriName);

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}
