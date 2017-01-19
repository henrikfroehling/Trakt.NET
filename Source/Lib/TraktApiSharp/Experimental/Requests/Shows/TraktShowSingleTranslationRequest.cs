namespace TraktApiSharp.Experimental.Requests.Shows
{
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowSingleTranslationRequest
    {
        internal TraktShowSingleTranslationRequest(TraktClient client) { }

        internal string LanguageCode { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();
            uriParams.Add("language", LanguageCode);
            return uriParams;
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public string UriTemplate => "shows/{id}/translations/{language}";
    }
}
