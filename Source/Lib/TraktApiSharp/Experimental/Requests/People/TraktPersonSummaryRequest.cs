namespace TraktApiSharp.Experimental.Requests.People
{
    using Base.Get;
    using Objects.Get.People;
    using TraktApiSharp.Requests;

    internal sealed class TraktPersonSummaryRequest : ATraktSingleItemGetByIdRequest<TraktPerson>
    {
        public TraktPersonSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "people/{id}{?extended}";
    }
}
