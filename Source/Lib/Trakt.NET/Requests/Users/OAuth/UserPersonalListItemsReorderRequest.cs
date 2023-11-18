namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Objects.Post.Basic;
    using Objects.Post.Basic.Responses;
    using System.Collections.Generic;

    internal sealed class UserPersonalListItemsReorderRequest : APostRequest<ITraktListItemsReorderPostResponse, ITraktListItemsReorderPost>, IHasUsername
    {
        public string Username { get; set; }

        public string Id { get; set; }

        public override ITraktListItemsReorderPost RequestBody { get; set; }

        public override string UriTemplate => "users/{username}/lists/{id}/items/reorder";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username,
                ["id"] = Id
            };

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");

            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "id not valid");
        }
    }
}
