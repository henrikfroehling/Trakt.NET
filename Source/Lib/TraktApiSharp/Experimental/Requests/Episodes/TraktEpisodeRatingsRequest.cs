namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeRatingsRequest : ATraktSingleItemGetByIdRequest<TraktRating>
    {
        internal TraktEpisodeRatingsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/ratings";
    }
}
