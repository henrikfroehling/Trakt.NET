namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Objects.Get.Lists;
    using System;
    using System.Collections.Generic;

    internal class UserListCollaborationsRequest : AGetRequest<ITraktList>
    {
        internal string Username { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/lists/collaborations";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username
            };

        public override void Validate()
        {
            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
