namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    internal sealed class TraktMovieAliasesRequest : ATraktMovieRequest<TraktMovieAlias>
    {
        public override string UriTemplate => "movies/{id}/aliases";
    }
}
