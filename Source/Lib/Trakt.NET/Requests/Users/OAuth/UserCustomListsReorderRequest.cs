namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Objects.Post.Users;
    using Objects.Post.Users.Responses;
    using System;
    using System.Collections.Generic;

    internal sealed class UserCustomListsReorderRequest : APostRequest<ITraktUserCustomListsReorderPostResponse, ITraktUserCustomListsReorderPost>
    {
        internal string Username { get; set; }

        public override ITraktUserCustomListsReorderPost RequestBody { get; set; }

        public override string UriTemplate => "users/{username}/lists/reorder";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username
            };

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
