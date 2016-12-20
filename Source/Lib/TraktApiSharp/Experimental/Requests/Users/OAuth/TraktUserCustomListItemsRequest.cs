namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Objects.Get.Users.Lists;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserCustomListItemsRequest : ATraktListGetByIdRequest<TraktListItem>
    {
        internal TraktUserCustomListItemsRequest(TraktClient client) : base(client) { }

        internal string Username { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/items{/type}{?extended}";
    }
}
