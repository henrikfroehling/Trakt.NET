namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserHiddenItemsRequest : ATraktUsersPaginationGetRequest<TraktUserHiddenItem>
    {
        internal TraktUserHiddenItemsRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => throw new NotImplementedException();
    }
}
