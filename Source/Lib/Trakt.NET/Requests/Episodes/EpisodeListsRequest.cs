namespace TraktNet.Requests.Episodes
{
    using Enums;
    using Interfaces;
    using Objects.Get.Lists;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class EpisodeListsRequest : AEpisodeRequest<ITraktList>, ISupportsPagination
    {
        internal TraktListType Type { get; set; }

        internal TraktListSortOrder SortOrder { get; set; }

        internal TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/lists{/type}{/sort_order}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            var isTypeSetAndValid = Type != null && Type != TraktListType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (isTypeSetAndValid && SortOrder != null && SortOrder != TraktListSortOrder.Unspecified)
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
