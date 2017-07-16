namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Objects.Post.Users.Responses.Implementations;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktUserFollowUserRequest : ATraktBodylessPostRequest<TraktUserFollowUserPostResponse>
    {
        internal string Username { get; set; }

        public override string UriTemplate => "users/{username}/follow";

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
