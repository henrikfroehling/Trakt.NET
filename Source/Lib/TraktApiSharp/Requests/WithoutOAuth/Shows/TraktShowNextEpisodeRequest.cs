namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Get.Shows.Episodes;

    internal class TraktShowNextEpisodeRequest : TraktGetByIdRequest<TraktEpisode, TraktEpisode>
    {
        internal TraktShowNextEpisodeRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/next_episode{?extended}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;
    }
}
