namespace TraktApiSharp.Requests.Shows
{
    using Base.Get;
    using Objects.Shows;

    internal class TraktShowSummaryRequest : TraktGetByIdRequest<TraktShow, TraktShow>
    {
        internal TraktShowSummaryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => false;
    }
}
