namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Interfaces;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonStatisticsRequest : ATraktSingleItemGetByIdRequest<TraktStatistics>, ITraktObjectRequest
    {
        internal TraktSeasonStatisticsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        public override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
