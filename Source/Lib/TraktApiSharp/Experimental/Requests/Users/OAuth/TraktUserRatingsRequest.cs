namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Ratings;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class TraktUserRatingsRequest //: ATraktUsersListGetRequest<TraktRatingsItem>
    {
        internal TraktUserRatingsRequest(TraktClient client) {}

        internal string Username { get; set; }

        internal TraktRatingsItemType Type { get; set; }

        internal int[] RatingFilter { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            uriParams.Add("username", Username);

            var isTypeSetAndValid = Type != null && Type != TraktRatingsItemType.Unspecified;

            if (isTypeSetAndValid)
                uriParams.Add("type", Type.UriName);

            if (RatingFilter != null && isTypeSetAndValid)
            {
                var ratingMin = RatingFilter.Min();
                var ratingMax = RatingFilter.Max();

                var isRatingsSetAndValid = RatingFilter.Length > 0 && RatingFilter.Length <= 10 && ratingMin >= 1 && ratingMax <= 10;

                if (isRatingsSetAndValid)
                    uriParams.Add("rating", string.Join(",", RatingFilter));
            }

            return uriParams;
        }
        
        public string UriTemplate => "users/{username}/ratings{/type}{/rating}{?extended}";
    }
}
