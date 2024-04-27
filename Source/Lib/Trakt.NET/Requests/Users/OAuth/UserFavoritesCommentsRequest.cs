namespace TraktNet.Requests.Users.OAuth
{
    using System.Collections.Generic;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Objects.Basic;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Interfaces;

    internal sealed class UserFavoritesCommentsRequest : AGetRequest<ITraktComment>, IHasUsername, ISupportsPagination
    {
        public string Username { get; set; }

        public TraktCommentSortOrder Sort { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.OptionalButMightBeRequired;

        public override string UriTemplate => "users/{username}/favorites/comments{/sort}{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                { "username", Username }
            };

            if (Sort != null && Sort != TraktWatchlistSortOrder.Unspecified)
                uriParams.Add("sort", Sort.UriName);

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (Username == null)
                throw new TraktRequestValidationException(nameof(Username), "username must not be null");

            if (Username == string.Empty || Username.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Username), "username not valid");
        }
    }
}
