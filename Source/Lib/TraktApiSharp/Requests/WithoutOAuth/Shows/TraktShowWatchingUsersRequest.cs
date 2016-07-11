namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktShowWatchingUsersRequest : TraktGetByIdRequest<IEnumerable<TraktUser>, TraktUser>
    {
        internal TraktShowWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/watching{?extended}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}
