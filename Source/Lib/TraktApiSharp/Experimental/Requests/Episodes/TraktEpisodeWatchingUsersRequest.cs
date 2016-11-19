namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktEpisodeWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>, ITraktObjectRequest, ITraktExtendedInfo
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) : base(client) { }

        internal uint SeasonNumber { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}";
    }
}
