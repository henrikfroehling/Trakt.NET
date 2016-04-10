namespace TraktApiSharp.Requests.Shows
{
    using Base.Get;
    using Objects.Shows;

    internal class TraktShowPeopleRequest : TraktGetByIdRequest<TraktShowPeople, TraktShowPeople>
    {
        internal TraktShowPeopleRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/people";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
