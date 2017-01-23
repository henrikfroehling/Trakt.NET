namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users.Lists;
    using System.Collections.Generic;

    internal class TraktEpisodeListsRequest : TraktGetByIdEpisodeRequest<TraktPaginationListResult<TraktList>, TraktList>
    {
        internal TraktEpisodeListsRequest(TraktClient client) : base(client) { }

        internal TraktListType Type { get; set; }

        internal TraktListSortOrder Sorting { get; set; }
        
        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            var isTypeSetAndValid = Type != null && Type != TraktListType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (isTypeSetAndValid && Sorting != null && Sorting != TraktListSortOrder.Unspecified)
                uriParams.Add("sorting", Sorting.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/lists{/type}{/sorting}{?page,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
