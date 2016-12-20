namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktMovieWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>, ITraktExtendedInfo
    {
        internal TraktMovieWatchingUsersRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "movies/{id}/watching{?extended}";
    }
}
