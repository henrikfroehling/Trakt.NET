namespace TraktNet.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class MovieAliasesRequest : AMovieRequest<ITraktMovieAlias>
    {
        public override string UriTemplate => "movies/{id}/aliases";
    }
}
