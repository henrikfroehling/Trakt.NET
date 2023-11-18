namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Objects.Post.Users.PersonalListItems;
    using Objects.Post.Users.PersonalListItems.Responses;
    using System.Collections.Generic;

    internal sealed class UserPersonalListItemsRemoveRequest : AUsersPostByIdRequest<ITraktUserPersonalListItemsRemovePostResponse, ITraktUserPersonalListItemsRemovePost>, IHasUsername
    {
        public string Username { get; set; }

        public override RequestObjectType RequestObjectType => RequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/items/remove";

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
