namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>, ITraktObjectRequest
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}";
    }
}
