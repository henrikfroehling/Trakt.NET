namespace TraktApiSharp.Requests.Movies
{
    using Base.Get;
    using Objects.Movies;

    internal class TraktMovieStatisticsRequest : TraktGetByIdRequest<TraktMovieStatistics, TraktMovieStatistics>
    {
        internal TraktMovieStatisticsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/stats";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;
    }
}
