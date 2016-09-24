namespace TraktApiSharp.Experimental.Requests.People
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.People;
    using TraktApiSharp.Requests;

    internal sealed class TraktPersonSummaryRequest : ATraktSingleItemGetByIdRequest<TraktPerson>, ITraktObjectRequest
    {
        public TraktPersonSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.People;

        public override string UriTemplate => "people/{id}{?extended}";
    }
}
