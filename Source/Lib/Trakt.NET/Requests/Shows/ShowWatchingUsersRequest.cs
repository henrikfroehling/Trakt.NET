namespace TraktNet.Requests.Shows
{
    using Interfaces;
    using Objects.Get.Users;
    using Parameters;
    using System.Collections.Generic;
    using TraktNet.Parameters;

    internal sealed class ShowWatchingUsersRequest : AShowRequest<ITraktUser>, ISupportsExtendedInfo
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "shows/{id}/watching{?extended}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }
    }
}
