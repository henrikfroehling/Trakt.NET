namespace TraktNet.Requests.Movies
{
    using Objects.Basic;

    internal sealed class MovieStatisticsRequest : AMovieRequest<ITraktStatistics>
    {
        public override string UriTemplate => "movies/{id}/stats";
    }
}
