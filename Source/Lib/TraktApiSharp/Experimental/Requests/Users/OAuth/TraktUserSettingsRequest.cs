namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Users;
    using System;

    internal sealed class TraktUserSettingsRequest : ATraktUsersSingleItemGetRequest<TraktUserSettings>
    {
        internal TraktUserSettingsRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
