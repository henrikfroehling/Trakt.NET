namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Interfaces;
    using Objects.Basic;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeStatisticsRequest : ATraktSingleItemGetByIdRequest<TraktStatistics>, ITraktObjectRequest, ITraktValidatable
    {
        internal TraktEpisodeStatisticsRequest(TraktClient client) : base(client) { }

        internal uint SeasonNumber { get; set; }

        internal uint EpisodeNumber { get; set; }

        public void Validate()
        {
            if (EpisodeNumber == 0)
                throw new ArgumentException("episode number must be a positive integer greater than zero", nameof(EpisodeNumber));
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/stats";
    }
}
