namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Interfaces;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSeasonSingleRequest : ITraktSupportsExtendedInfo
    {
        internal TraktSeasonSingleRequest(TraktClient client)  { }

        internal uint SeasonNumber { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("season", SeasonNumber.ToString());
            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        public string UriTemplate => "shows/{id}/seasons/{season}{?extended}";
    }
}
