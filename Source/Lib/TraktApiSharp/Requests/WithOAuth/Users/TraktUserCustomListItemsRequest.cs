namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Get.Users.Lists;
    using System.Collections.Generic;

    internal class TraktUserCustomListItemsRequest : TraktGetByIdRequest<IEnumerable<TraktListItem>, TraktListItem>
    {
        internal TraktUserCustomListItemsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktListItemType Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktListItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/items{/type}{?extended}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Lists;

        protected override bool IsListResult => true;
    }
}
