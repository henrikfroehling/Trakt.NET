namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieRatingsRequest : ATraktSingleItemGetByIdRequest<TraktRating>
    {
        internal TraktMovieRatingsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "movies/{id}/ratings";
    }
}
