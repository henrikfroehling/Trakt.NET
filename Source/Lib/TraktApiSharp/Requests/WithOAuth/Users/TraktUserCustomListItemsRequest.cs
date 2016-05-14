namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users.Lists;
    using System.Collections.Generic;

    internal class TraktUserCustomListItemsRequest : TraktGetByIdRequest<TraktListResult<TraktListItem>, TraktListItem>
    {
        internal TraktUserCustomListItemsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktListItemType? Type { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id },
                                                    { "username", Username },
                                                    { "type", Type.HasValue ? Type.Value.AsStringUriParameter() : string.Empty } };
        }

        protected override string UriTemplate => "users/{username}/lists/{id}/items/{type}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Lists;

        protected override bool IsListResult => true;
    }
}
