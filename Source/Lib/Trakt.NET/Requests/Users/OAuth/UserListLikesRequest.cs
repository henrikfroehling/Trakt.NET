namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Get.Lists;
    using System.Collections.Generic;

    internal sealed class UserListLikesRequest : AGetRequest<ITraktListLike>, ISupportsPagination
    {
        internal string Username { get; set; }

        public string ListId { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/lists/{list_id}/likes{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                { "username", Username },
                { "list_id", ListId }
            };

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

            if (ListId == null)
                throw new TraktRequestValidationException(nameof(ListId), "list id must not be null");

            if (ListId == string.Empty || ListId.ContainsSpace())
                throw new TraktRequestValidationException(nameof(ListId), "list id not valid");
        }
    }
}
