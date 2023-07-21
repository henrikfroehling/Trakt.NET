namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using System.Collections.Generic;

    internal sealed class UserPersonalListItemUpdateRequest : AListItemUpdateRequest, IHasId
    {
        internal string Username { get; set; }

        public string Id { get; set; }

        public override string UriTemplate => "users/{username}/lists/{list_id}/items/{list_item_id}";

        public RequestObjectType RequestObjectType => RequestObjectType.Lists;

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var parameters = base.GetUriPathParameters();

            parameters.Add("username", Username);
            parameters.Add("list_id", Id);

            return parameters;
        }

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");

            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "list id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "list id not valid");
        }
    }
}
