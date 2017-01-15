namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Watched;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserWatchedShowsRequest : ATraktUsersListGetRequest<TraktWatchedShow>
    {
        internal TraktUserWatchedShowsRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => throw new NotImplementedException();
    }
}
