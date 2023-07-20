namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Post.Basic;
    using System.Collections.Generic;

    internal sealed class UserPersonalListItemUpdateRequest : APutRequest<ITraktListItemUpdatePost>, IHasId
    {
        internal string Username { get; set; }

        public string Id { get; set; }

        internal uint ListItemId { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{list_id}/items/{list_item_id}";

        public override ITraktListItemUpdatePost RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username,
                ["list_id"] = Id,
                ["list_item_id"] = ListItemId.ToString()
            };

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");

            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "list id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "list id not valid");

            if (ListItemId == 0)
                throw new TraktRequestValidationException(nameof(ListItemId), "list item id must not be 0");
        }
    }
}
