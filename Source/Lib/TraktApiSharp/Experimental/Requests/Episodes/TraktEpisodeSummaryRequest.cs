namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeSummaryRequest : ATraktSingleItemGetByIdRequest<TraktEpisode>
    {
        internal TraktEpisodeSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}{?extended}";
    }
}
