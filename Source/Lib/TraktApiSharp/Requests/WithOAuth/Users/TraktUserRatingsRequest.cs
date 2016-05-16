namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserRatingsRequest : TraktGetRequest<TraktListResult<TraktUserRatingsItem>, TraktUserRatingsItem>
    {
        internal TraktUserRatingsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktSyncRatingsItemType? Type { get; set; }

        internal int[] Rating { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type.HasValue && Type.Value != TraktSyncRatingsItemType.Unspecified)
                uriParams.Add("type", Type.Value.AsStringUriParameter());

            if (Rating != null && Rating.Length > 0)
                uriParams.Add("rating", string.Join(",", Rating));

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/ratings{/type}{/rating}";

        protected override bool IsListResult => true;
    }
}
