namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Enums;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonCommentsRequest
    {
        internal TraktSeasonCommentsRequest(TraktClient client) { }

        internal uint SeasonNumber { get; set; }

        internal TraktCommentSortOrder Sorting { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            uriParams.Add("season", SeasonNumber.ToString());

            if (Sorting != null && Sorting != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sorting", Sorting.UriName);

            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        public string UriTemplate => "shows/{id}/seasons/{season}/comments{/sorting}{?page,limit}";
    }
}
