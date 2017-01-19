namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Interfaces;
    using Objects.Get.Ratings;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSyncRatingsRequest : ATraktSyncListGetRequest<TraktRatingsItem>, ITraktSupportsExtendedInfo
    {
        internal TraktSyncRatingsRequest(TraktClient client) : base(client) { }

        internal TraktRatingsItemType Type { get; set; }

        internal int[] Ratings { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            var isTypeSetAndValid = Type != null && Type != TraktRatingsItemType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (Ratings != null && isTypeSetAndValid)
            {
                var ratingsMin = Ratings.Min();
                var ratingsMax = Ratings.Max();

                var isRatingsSetAndValid = Ratings.Length > 0 && Ratings.Length <= 10 && ratingsMin >= 1 && ratingsMax <= 10;

                if (isRatingsSetAndValid)
                    uriParams.Add("rating", string.Join(",", Ratings));
            }

            return uriParams;
        }

        public override string UriTemplate => "sync/ratings{/type}{/rating}{?extended}";
    }
}
