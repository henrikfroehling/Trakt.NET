namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Enums;
    using Objects.Get.Ratings;
    using System.Collections.Generic;
    using System.Linq;

    internal class TraktSyncRatingsRequest : TraktGetRequest<IEnumerable<TraktRatingsItem>, TraktRatingsItem>
    {
        internal TraktSyncRatingsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktRatingsItemType Type { get; set; }

        internal int[] Rating { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            var isTypeSetAndValid = Type != null && Type != TraktRatingsItemType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (Rating != null && isTypeSetAndValid)
            {
                var ratingMin = Rating.Min();
                var ratingMax = Rating.Max();

                var isRatingsSetAndValid = Rating.Length > 0 && Rating.Length <= 10 && ratingMin >= 1 && ratingMax <= 10;

                if (isRatingsSetAndValid)
                    uriParams.Add("rating", string.Join(",", Rating));
            }

            return uriParams;
        }

        protected override string UriTemplate => "sync/ratings{/type}{/rating}{?extended}";

        protected override bool IsListResult => true;
    }
}
