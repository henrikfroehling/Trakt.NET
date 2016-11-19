namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Interfaces;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeRatingsRequest : ATraktSingleItemGetByIdRequest<TraktRating>, ITraktObjectRequest
    {
        internal TraktEpisodeRatingsRequest(TraktClient client) : base(client) { }

        internal uint SeasonNumber { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/ratings";
    }
}
