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

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type.HasValue && Type != TraktSyncRatingsItemType.Unspecified)
                uriParams.Add("type", Type.Value.AsString());

            if (Rating != null && Rating.Length > 0)
                uriParams.Add("rating", string.Join(",", Rating));

            return uriParams;
        }

        protected override string UriTemplate => "sync/ratings{/type}{/rating}";

        protected override bool IsListResult => true;
    }
}
