namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Basic;

    internal class TraktMovieRatingsRequest : TraktGetByIdRequest<TraktRating, TraktRating>
    {
        internal TraktMovieRatingsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/ratings";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;
    }
}
