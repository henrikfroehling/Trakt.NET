namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonStatisticsRequest : ATraktSingleItemGetByIdRequest<TraktStatistics>
    {
        internal TraktSeasonStatisticsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
