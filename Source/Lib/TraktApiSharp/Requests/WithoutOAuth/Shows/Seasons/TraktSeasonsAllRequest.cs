namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Seasons;

    internal class TraktSeasonsAllRequest : TraktGetByIdRequest<TraktListResult<TraktSeason>, TraktSeason>
    {
        internal TraktSeasonsAllRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/seasons";

        protected override bool IsListResult => true;

        protected override bool UsesSeasonExtendedOption => true;
    }
}
