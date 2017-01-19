namespace TraktApiSharp.Experimental.Requests.People
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktPersonSummaryRequest : ITraktSupportsExtendedInfo
    {
        internal TraktPersonSummaryRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.People;

        public string UriTemplate => "people/{id}{?extended}";
    }
}
