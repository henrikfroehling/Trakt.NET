namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System;

    internal sealed class TraktUserProfileRequest : ATraktUsersSingleItemGetRequest<TraktUser>
    {
        internal TraktUserProfileRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
