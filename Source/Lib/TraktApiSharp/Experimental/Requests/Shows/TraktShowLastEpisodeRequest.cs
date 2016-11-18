namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowLastEpisodeRequest : ATraktSingleItemGetByIdRequest<TraktEpisode>
    {
        public TraktShowLastEpisodeRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/last_episode{?extended}";
    }
}
