namespace TraktApiSharp.Requests.Episodes
{
    using Enums;
    using Interfaces;
    using Objects.Get.Users.Lists.Implementations;
    using System.Collections.Generic;

    internal sealed class TraktEpisodeListsRequest : ATraktEpisodeRequest<TraktList>, ITraktSupportsPagination
    {
        internal TraktListType Type { get; set; }

        internal TraktListSortOrder SortOrder { get; set; }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/lists{/type}{/sort_order}{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            var isTypeSetAndValid = Type != null && Type != TraktListType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (isTypeSetAndValid && SortOrder != null && SortOrder != TraktListSortOrder.Unspecified)
                uriParams.Add("sort_order", SortOrder.UriName);

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}
