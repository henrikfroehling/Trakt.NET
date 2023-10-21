namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using System.Collections.Generic;

    internal sealed class UserListLikeRequest : ABodylessPostRequest, IHasId, IHasUsername
    {
        public string Username { get; set; }

        public string Id { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/like";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username,
                ["id"] = Id
            };

        public override void Validate()
        {
            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");

            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "list id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "list id not valid");
        }
    }
}
