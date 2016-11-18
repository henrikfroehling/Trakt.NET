namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowLastEpisodeRequest : ATraktSingleItemGetByIdRequest<TraktEpisode>, ITraktObjectRequest
    {
        public TraktShowLastEpisodeRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/last_episode{?extended}";
    }
}
