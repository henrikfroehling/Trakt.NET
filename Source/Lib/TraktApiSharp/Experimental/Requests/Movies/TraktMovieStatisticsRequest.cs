namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Basic;

    internal sealed class TraktMovieStatisticsRequest : ATraktMovieRequest<TraktStatistics>
    {
        public override string UriTemplate => "movies/{id}/stats";
    }
}
