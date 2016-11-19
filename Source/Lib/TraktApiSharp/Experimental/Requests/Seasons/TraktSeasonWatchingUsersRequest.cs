namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Users;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSeasonWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>, ITraktObjectRequest, ITraktExtendedInfo
    {
        internal TraktSeasonWatchingUsersRequest(TraktClient client) : base(client) { }

        internal uint SeasonNumber { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        public override string UriTemplate => "shows/{id}/seasons/{season}/watching{?extended}";
    }
}
