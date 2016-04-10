namespace TraktApiSharp.Requests.Shows.Seasons
{
    using Base.Get;
    using Objects;
    using Objects.Shows.Seasons;

    internal class TraktSeasonsAllRequest : TraktGetByIdRequest<TraktListResult<TraktSeason>, TraktSeason>
    {
        internal TraktSeasonsAllRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/seasons";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;
    }
}
