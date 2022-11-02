namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Get.Lists;
    using System.Collections.Generic;

    internal sealed class UserPersonalListItemsRequest : AUsersPagedGetRequest<ITraktListItem>, IHasId
    {
        internal string Username { get; set; }

        public string Id { get; set; }

        internal TraktListItemType Type { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Lists;

        public override string UriTemplate => "users/{username}/lists/{id}/items{/type}{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);
            uriParams.Add("id", Id);

            if (Type != null && Type != TraktListItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
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
