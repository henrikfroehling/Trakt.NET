namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Enums;
    using Interfaces;
    using Objects.Get.Ratings;
    using Parameters;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Ratings.Implementations;

    internal sealed class TraktSyncRatingsRequest : ATraktSyncGetRequest<TraktRatingsItem>, ITraktSupportsExtendedInfo
    {
        internal TraktRatingsItemType Type { get; set; }

        internal int[] RatingFilter { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "sync/ratings{/type}{/rating}{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            var isTypeSetAndValid = Type != null && Type != TraktRatingsItemType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (RatingFilter != null && isTypeSetAndValid)
            {
                var ratingsMin = RatingFilter.Min();
                var ratingsMax = RatingFilter.Max();

                var isRatingsSetAndValid = RatingFilter.Length > 0 && RatingFilter.Length <= 10 && ratingsMin >= 1 && ratingsMax <= 10;

                if (isRatingsSetAndValid)
                    uriParams.Add("rating", string.Join(",", RatingFilter));
            }

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
