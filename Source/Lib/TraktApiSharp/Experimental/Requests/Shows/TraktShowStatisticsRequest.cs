namespace TraktApiSharp.Experimental.Requests.Shows
{
    using TraktApiSharp.Requests;

    internal sealed class TraktShowStatisticsRequest
    {
        internal TraktShowStatisticsRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public string UriTemplate => "shows/{id}/stats";
    }
}
