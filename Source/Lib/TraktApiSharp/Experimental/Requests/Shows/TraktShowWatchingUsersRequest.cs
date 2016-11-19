namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>, ITraktObjectRequest
    {
        public TraktShowWatchingUsersRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/watching{?extended}";
    }
}
