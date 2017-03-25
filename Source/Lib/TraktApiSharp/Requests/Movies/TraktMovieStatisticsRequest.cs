namespace TraktApiSharp.Requests.Movies
{
    using Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;

    internal sealed class TraktMovieStatisticsRequest : ATraktMovieRequest<TraktStatistics>
    {
        public override string UriTemplate => "movies/{id}/stats";
    }
}
