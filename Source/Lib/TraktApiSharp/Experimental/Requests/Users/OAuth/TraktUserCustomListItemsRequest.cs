namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Enums;
    using Objects.Get.Users.Lists;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListItemsRequest : ATraktListGetByIdRequest<TraktListItem>
    {
        internal TraktUserCustomListItemsRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        internal TraktListItemType Type { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/lists/{id}/items{/type}{?extended}";
    }
}
