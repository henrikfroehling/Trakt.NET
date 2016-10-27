namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>, ITraktObjectRequest
    {
        internal TraktMovieWatchingUsersRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "movies/{id}/watching{?extended}";
    }
}
