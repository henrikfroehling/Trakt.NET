namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Objects.Get.Lists;
    using Objects.Post.Users;
    using System;
    using System.Collections.Generic;

    internal sealed class UserCustomListAddRequest : APostRequest<ITraktList, ITraktUserCustomListPost>
    {
        internal string Username { get; set; }

        public override ITraktUserCustomListPost RequestBody { get; set; }

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
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
