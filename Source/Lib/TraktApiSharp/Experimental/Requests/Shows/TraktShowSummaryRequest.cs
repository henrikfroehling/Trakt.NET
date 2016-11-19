namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowSummaryRequest : ATraktSingleItemGetByIdRequest<TraktShow>
    {
        public TraktShowSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}{?extended}";
    }
}
