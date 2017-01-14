namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Ratings;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRatingsRequest : ATraktUsersListGetRequest<TraktRatingsItem>
    {
        internal TraktUserRatingsRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => throw new NotImplementedException();
    }
}
