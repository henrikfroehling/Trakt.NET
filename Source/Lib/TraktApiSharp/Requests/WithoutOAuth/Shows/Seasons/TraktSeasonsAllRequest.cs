namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Seasons;

    internal class TraktSeasonsAllRequest : TraktGetByIdRequest<TraktListResult<TraktSeason>, TraktSeason>
    {
        internal TraktSeasonsAllRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/seasons{?extended}";

        protected override bool IsListResult => true;
    }
}
