namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Collection;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCollectionShowsRequest : ATraktUsersListGetRequest<TraktCollectionShow>
    {
        internal TraktUserCollectionShowsRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => throw new NotImplementedException();
    }
}
