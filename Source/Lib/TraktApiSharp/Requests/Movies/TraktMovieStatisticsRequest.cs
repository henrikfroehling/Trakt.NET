namespace TraktApiSharp.Requests.Movies
{
    using Objects.Basic;

    internal sealed class TraktMovieStatisticsRequest : AMovieRequest<ITraktStatistics>
    {
        public override string UriTemplate => "movies/{id}/stats";
    }
}
