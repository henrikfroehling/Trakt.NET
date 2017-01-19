namespace TraktApiSharp.Experimental.Requests.Shows
{
    using TraktApiSharp.Requests;

    internal sealed class TraktShowRatingsRequest
    {
        internal TraktShowRatingsRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public string UriTemplate => "shows/{id}/ratings";
    }
}
