namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktEpisodeWatchingUsersRequest : ITraktSupportsExtendedInfo, ITraktValidatable
    {
        internal TraktEpisodeWatchingUsersRequest(TraktClient client) { }

        internal uint SeasonNumber { get; set; }

        internal uint EpisodeNumber { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            uriParams.Add("season", SeasonNumber.ToString());
            uriParams.Add("episode", EpisodeNumber.ToString());

            return uriParams;
        }

        public void Validate()
        {
            if (EpisodeNumber == 0)
                throw new ArgumentException("episode number must be a positive integer greater than zero", nameof(EpisodeNumber));
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        public string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}";
    }
}
