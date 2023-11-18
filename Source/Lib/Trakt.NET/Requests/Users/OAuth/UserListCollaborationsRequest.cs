namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Objects.Get.Lists;
    using System.Collections.Generic;

    internal class UserListCollaborationsRequest : AGetRequest<ITraktList>, IHasUsername
    {
        public string Username { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.OptionalButMightBeRequired;

        public override string UriTemplate => "users/{username}/lists/collaborations";

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
