namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Exceptions;
    using Extensions;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class UserFavoritesRequest : AUsersPagedGetRequest<ITraktFavorite>, IHasUsername
    {
        public string Username { get; set; }

        public override string UriTemplate => "users/{username}/favorites{/type}{/sort}{?extended,page,limit}";

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public TraktFavoriteObjectType Type { get; set; }

        public TraktWatchlistSortOrder Sort { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktFavoriteObjectType.Unspecified)
            {
                uriParams.Add("type", Type.UriName);

                if (Sort != null && Sort != TraktWatchlistSortOrder.Unspecified)
                    uriParams.Add("sort", Sort.UriName);
            }

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
