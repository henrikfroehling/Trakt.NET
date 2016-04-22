namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Get.Shows;

    internal class TraktShowRatingsRequest : TraktGetByIdRequest<TraktShowRating, TraktShowRating>
    {
        internal TraktShowRatingsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/ratings";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => false;
    }
}
