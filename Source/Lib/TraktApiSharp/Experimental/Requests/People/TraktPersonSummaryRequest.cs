namespace TraktApiSharp.Experimental.Requests.People
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.People;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktPersonSummaryRequest : ATraktSingleItemGetByIdRequest<TraktPerson>, ITraktObjectRequest, ITraktExtendedInfo
    {
        internal TraktPersonSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedOption ExtendedOption { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.People;

        public override string UriTemplate => "people/{id}{?extended}";
    }
}
