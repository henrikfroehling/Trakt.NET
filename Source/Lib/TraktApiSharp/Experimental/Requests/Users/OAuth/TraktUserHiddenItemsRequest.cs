namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserHiddenItemsRequest : ATraktUsersPaginationGetRequest<TraktUserHiddenItem>
    {
        internal TraktUserHiddenItemsRequest(TraktClient client) : base(client) {}

        internal TraktHiddenItemsSection Section { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/hidden/{section}{?type,extended,page,limit}";
    }
}
