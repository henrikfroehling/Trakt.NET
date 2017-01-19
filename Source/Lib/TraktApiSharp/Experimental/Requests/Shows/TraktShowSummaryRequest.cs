namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Shows;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktShowSummaryRequest : ATraktSingleItemGetByIdRequest<TraktShow>, ITraktSupportsExtendedInfo
    {
        internal TraktShowSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}{?extended}";
    }
}
