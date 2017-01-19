namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Users;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktEpisodeWatchingUsersRequest : ATraktListGetByIdRequest<TraktUser>, ITraktSupportsExtendedInfo, ITraktValidatable
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) : base(client) { }

        internal uint SeasonNumber { get; set; }

        internal uint EpisodeNumber { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("season", SeasonNumber.ToString());
            uriParams.Add("episode", EpisodeNumber.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (EpisodeNumber == 0)
                throw new ArgumentException("episode number must be a positive integer greater than zero", nameof(EpisodeNumber));
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}";
    }
}
