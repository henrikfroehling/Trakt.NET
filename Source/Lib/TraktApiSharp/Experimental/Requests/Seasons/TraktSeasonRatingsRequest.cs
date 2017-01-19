namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonRatingsRequest
    {
        internal TraktSeasonRatingsRequest(TraktClient client) { }

        internal uint SeasonNumber { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("season", SeasonNumber.ToString());
            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        public string UriTemplate => "shows/{id}/seasons/{season}/ratings";
    }
}
