namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Get.Lists;
    using Objects.Post.Users;
    using System.Collections.Generic;

    internal sealed class UserPersonalListUpdateRequest : APutRequest<ITraktList, ITraktUserPersonalListPost>, IHasId
    {
        internal string Username { get; set; }

        public string Id { get; set; }

        public override ITraktUserPersonalListPost RequestBody { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username,
                ["id"] = Id
            };

        public override void Validate()
        {
            if (EqualityComparer<ITraktUserPersonalListPost>.Default.Equals(RequestBody, default))
                throw new TraktRequestValidationException(nameof(RequestBody), "request body must not be null");

            if (!RequestBody.HasAnyValuesSet())
                throw new TraktRequestValidationException(nameof(RequestBody), "no list specific values set");

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
