namespace TraktApiSharp.Requests.Shows
{
    using Objects.Basic;

    internal sealed class ShowStatisticsRequest : AShowRequest<ITraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/stats";
    }
}
