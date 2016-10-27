namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Objects.Get.Movies;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieSingleTranslationRequest : ATraktSingleItemGetByIdRequest<TraktMovieTranslation>
    {
        internal TraktMovieSingleTranslationRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "movies/{id}/translations/{language}";
    }
}
