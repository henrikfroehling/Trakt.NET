namespace TraktNet.Requests.Users.OAuth
{
    using Exceptions;
    using Extensions;
    using Objects.Get.Watched;
    using System.Collections.Generic;

    internal sealed class UserWatchedMoviesRequest : AUsersGetRequest<ITraktWatchedMovie>
    {
        internal string Username { get; set; }

        public override string UriTemplate => "users/{username}/watched/movies{?extended}";

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
