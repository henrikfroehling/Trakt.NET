namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Syncs.Ratings;
    using System.Collections.Generic;

    internal class TraktSyncRatingsRequest : TraktGetRequest<TraktListResult<TraktSyncRatingsItem>, TraktSyncRatingsItem>
    {
        internal TraktSyncRatingsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        internal TraktSyncRatingsItemType? Type { get; set; }

        internal int[] Rating { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "type", Type.HasValue ? Type.Value.AsString() : string.Empty },
                                                    { "rating", Rating.Length > 0 ? Rating.ToString() : string.Empty } };
        }

        protected override string UriTemplate => "sync/ratings/{type}/{rating}";

        protected override bool IsListResult => true;
    }
}
