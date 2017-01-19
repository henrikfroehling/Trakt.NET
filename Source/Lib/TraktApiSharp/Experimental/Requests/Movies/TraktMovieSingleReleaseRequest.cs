namespace TraktApiSharp.Experimental.Requests.Movies
{
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieSingleReleaseRequest
    {
        internal TraktMovieSingleReleaseRequest(TraktClient client) { }

        internal string LanguageCode { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("language", LanguageCode);
            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public string UriTemplate => "movies/{id}/releases/{language}";
    }
}
