namespace TraktApiSharp.Requests.Shows
{
    using Objects.Basic;

    internal sealed class TraktShowStatisticsRequest : ATraktShowRequest<ITraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/stats";
    }
}
