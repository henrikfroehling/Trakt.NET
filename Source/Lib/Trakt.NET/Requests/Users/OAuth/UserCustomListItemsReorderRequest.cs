namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Objects.Post.Users;
    using Objects.Post.Users.Responses;
    using System;
    using System.Collections.Generic;

    internal sealed class UserCustomListItemsReorderRequest : APostRequest<ITraktUserCustomListsReorderPostResponse, ITraktUserCustomListsReorderPost>
    {
        internal string Username { get; set; }

        public string Id { get; set; }

        public override ITraktUserCustomListsReorderPost RequestBody { get; set; }

        public override string UriTemplate => "users/{username}/lists/{id}/items/reorder";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["username"] = Username,
                ["id"] = Id
            };

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new ArgumentNullException($"{nameof(Username)} must not be null", default(Exception));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException($"{nameof(Username)} is not valid");

            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("id not valid", nameof(Id));
        }
    }
}
