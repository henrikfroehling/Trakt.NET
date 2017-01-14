namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Ratings;
    using System;

    internal sealed class TraktUserRatingsRequest : ATraktUsersListGetRequest<TraktRatingsItem>
    {
        internal TraktUserRatingsRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
