namespace TraktApiSharp.Requests.Episodes
{
    using Interfaces;
    using Objects.Get.Users.Implementations;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class TraktEpisodeWatchingUsersRequest : ATraktEpisodeRequest<TraktUser>, ITraktSupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
