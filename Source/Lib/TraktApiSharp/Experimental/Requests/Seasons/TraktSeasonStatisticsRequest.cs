namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Interfaces;
    using Objects.Basic;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonStatisticsRequest : ATraktSingleItemGetByIdRequest<TraktStatistics>, ITraktObjectRequest
    {
        internal TraktSeasonStatisticsRequest(TraktClient client) : base(client) { }

        internal uint SeasonNumber { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        public override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
