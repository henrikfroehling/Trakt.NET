namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Interfaces;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowPeopleRequest : ATraktSingleItemGetByIdRequest<TraktCastAndCrew>, ITraktObjectRequest
    {
        public TraktShowPeopleRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/people{?extended}";
    }
}
