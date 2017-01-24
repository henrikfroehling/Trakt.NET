namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users.Lists;
    using System.Collections.Generic;

    internal class TraktMovieListsRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktList>, TraktList>
    {
        internal TraktMovieListsRequest(TraktClient client) : base(client) { }

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

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override string UriTemplate => "movies/{id}/lists{/type}{/sorting}{?page,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
