namespace TraktApiSharp.Requests.WithoutOAuth.People
{
    using Base.Get;
    using Objects.Get.People;

    internal class TraktPersonSummaryRequest : TraktGetByIdRequest<TraktPerson, TraktPerson>
    {
        internal TraktPersonSummaryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.People;

        protected override string UriTemplate => "people/{id}{?extended}";
    }
}
