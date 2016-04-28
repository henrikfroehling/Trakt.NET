namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserWatchlistRequest : TraktGetRequest<TraktListResult<TraktUserWatchlistItem>, TraktUserWatchlistItem>
    {
        internal TraktUserWatchlistRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

        internal string Username { get; set; }

        internal TraktSyncWatchlistItemType? Type { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "username", Username },
                                                    { "type", Type.HasValue ? Type.Value.AsString() : string.Empty } };
        }

        protected override string UriTemplate => "users/{username}/watchlist/{type}";

        protected override bool IsListResult => true;
    }
}
