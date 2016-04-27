namespace TraktApiSharp.Requests.WithoutOAuth.People
{
    using Base.Get;
    using Objects.Get.People.Credits;

    internal class TraktPersonShowCreditsRequest : TraktGetByIdRequest<TraktPersonShowCredits, TraktPersonShowCredits>
    {
        internal TraktPersonShowCreditsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool IsListResult => false;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.People;

        protected override string UriTemplate => "people/{id}/shows";
    }
}
