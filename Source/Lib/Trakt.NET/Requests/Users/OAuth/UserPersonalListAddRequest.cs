namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Objects.Get.Lists;
    using Objects.Post.Users;
    using System.Collections.Generic;

    internal sealed class UserPersonalListAddRequest : APostRequest<ITraktList, ITraktUserPersonalListPost>
    {
        internal string Username { get; set; }

        public override ITraktUserPersonalListPost RequestBody { get; set; }

        public override string UriTemplate => "users/{username}/lists";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username
            };

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");
        }
    }
}
