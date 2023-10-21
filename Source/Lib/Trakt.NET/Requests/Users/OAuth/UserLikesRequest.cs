namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class UserLikesRequest : AGetRequest<ITraktUserLikeItem>, ISupportsPagination, IHasUsername
    {
        public string Username { get; set; }

        internal TraktUserLikeType Type { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.OptionalButMightBeRequired;

        public override string UriTemplate => "users/{username}/likes{/type}{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                { "username", Username }
            };

            if (Type != null && Type != TraktUserLikeType.Unspecified)
                uriParams.Add("type", Type.UriName);

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
