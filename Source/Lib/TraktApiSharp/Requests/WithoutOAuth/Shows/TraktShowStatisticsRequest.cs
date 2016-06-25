namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Get.Shows;

    internal class TraktShowStatisticsRequest : TraktGetByIdRequest<TraktShowStatistics, TraktShowStatistics>
    {
        internal TraktShowStatisticsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/stats";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;
    }
}
