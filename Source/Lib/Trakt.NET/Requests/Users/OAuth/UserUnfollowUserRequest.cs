namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using System.Collections.Generic;

    internal sealed class UserUnfollowUserRequest : ADeleteRequest, IHasUsername
    {
        public string Username { get; set; }

        public override string UriTemplate => "users/{username}/follow";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username
            };

        public override void Validate()
        {
            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");
        }
    }
}
