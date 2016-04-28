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

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username },
                                                    { "type", Type.HasValue ? Type.Value.AsString() : string.Empty },
                                                    { "rating", Rating.Length > 0 ? Rating.ToString() : string.Empty } };
        }

        protected override string UriTemplate => "users/{username}/ratings/{type}/{rating}";

        protected override bool IsListResult => true;
    }
}
