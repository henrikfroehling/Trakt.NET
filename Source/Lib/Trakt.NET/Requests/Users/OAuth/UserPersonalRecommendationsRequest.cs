namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Extensions;
    using Objects.Get.Users;
    using System;
    using System.Collections.Generic;

    internal sealed class UserPersonalRecommendationsRequest : AUsersPagedGetRequest<ITraktRecommendation>
    {
        internal string Username { get; set; }

        public override string UriTemplate => "users/{username}/recommendations{/type}{/sort}{?extended,page,limit}";

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public TraktRecommendationObjectType Type { get; set; }

        public TraktWatchlistSortOrder Sort { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktRecommendationObjectType.Unspecified)
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
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
