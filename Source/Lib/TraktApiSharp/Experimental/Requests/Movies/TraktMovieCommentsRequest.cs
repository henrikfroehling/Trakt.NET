namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Enums;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieCommentsRequest
    {
        internal TraktMovieCommentsRequest(TraktClient client) { }

        internal TraktCommentSortOrder Sorting { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Sorting != null && Sorting != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sorting", Sorting.UriName);

            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public string UriTemplate => "movies/{id}/comments{/sorting}{?page,limit}";
    }
}
