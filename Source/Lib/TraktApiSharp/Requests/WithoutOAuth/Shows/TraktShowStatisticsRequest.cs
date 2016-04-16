namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Shows;

    internal class TraktShowStatisticsRequest : TraktGetByIdRequest<TraktShowStatistics, TraktShowStatistics>
    {
        internal TraktShowStatisticsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/stats";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => false;
    }
}
