namespace TraktApiSharp.Requests.Users.OAuth
{
    using Enums;
    using Extensions;
    using Objects.Get.Ratings.Implementations;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class TraktUserRatingsRequest : ATraktUsersGetRequest<TraktRatingsItem>
    {
        internal string Username { get; set; }

        internal TraktRatingsItemType Type { get; set; }

        internal int[] RatingFilter { get; set; }

        public override string UriTemplate => "users/{username}/ratings{/type}{/rating}{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

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

        public override void Validate()
        {
            base.Validate();

            if (Username == null)
                throw new ArgumentNullException(nameof(Username));

            if (Username == string.Empty || Username.ContainsSpace())
                throw new ArgumentException("username not valid", nameof(Username));
        }
    }
}
