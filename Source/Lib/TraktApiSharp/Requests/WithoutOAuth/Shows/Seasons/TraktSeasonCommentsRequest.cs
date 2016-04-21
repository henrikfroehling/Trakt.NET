namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Basic;
    using Objects.Get.Shows.Seasons;

    internal class TraktSeasonCommentsRequest : TraktGetByIdSeasonRequest<TraktPaginationListResult<TraktSeasonComment>, TraktSeasonComment>
    {
        internal TraktSeasonCommentsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/comments";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        protected override bool IsListResult => true;
    }
}
