namespace TraktApiSharp.Requests.Shows
{
    using Base.Get;
    using Objects.Shows;

    internal class TraktShowRatingsRequest : TraktGetByIdRequest<TraktShowRating, TraktShowRating>
    {
        internal TraktShowRatingsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/ratings";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;
    }
}
