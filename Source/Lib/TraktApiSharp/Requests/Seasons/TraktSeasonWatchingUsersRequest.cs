namespace TraktApiSharp.Requests.Seasons
{
    using Interfaces;
    using Objects.Get.Users;
    using Parameters;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Users.Implementations;

    internal sealed class TraktSeasonWatchingUsersRequest : ATraktSeasonRequest<TraktUser>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/watching{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
