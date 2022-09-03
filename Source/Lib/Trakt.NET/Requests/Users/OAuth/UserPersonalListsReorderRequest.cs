namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Objects.Post.Basic;
    using Objects.Post.Basic.Responses;
    using System;
    using System.Collections.Generic;

    internal sealed class UserPersonalListsReorderRequest : APostRequest<ITraktListItemsReorderPostResponse, ITraktListItemsReorderPost>
    {
        internal string Username { get; set; }

        public override ITraktListItemsReorderPost RequestBody { get; set; }

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
                throw new ArgumentNullException($"{nameof(Username)} must not be null", default(Exception));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException($"{nameof(Username)} is not valid");
        }
    }
}
