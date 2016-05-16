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

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("username", Username);

            if (Type.HasValue && Type.Value != TraktSyncWatchlistItemType.Unspecified)
                uriParams.Add("type", Type.Value.AsStringUriParameter());

            return uriParams;
        }

        protected override string UriTemplate => "users/{username}/watchlist/{type}";

        protected override bool IsListResult => true;
    }
}
