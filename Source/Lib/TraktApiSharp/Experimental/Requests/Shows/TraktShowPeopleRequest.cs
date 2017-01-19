namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktShowPeopleRequest : ITraktSupportsExtendedInfo
    {
        internal TraktShowPeopleRequest(TraktClient client){ }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public string UriTemplate => "shows/{id}/people{?extended}";
    }
}
