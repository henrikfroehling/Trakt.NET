namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class UserFollowersRequest : AUsersGetRequest<ITraktUserFollower>, IHasUsername
    {
        public string Username { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.OptionalButMightBeRequired;

        public override string UriTemplate => "users/{username}/followers{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("username", Username);
            return uriParams;
        }

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
