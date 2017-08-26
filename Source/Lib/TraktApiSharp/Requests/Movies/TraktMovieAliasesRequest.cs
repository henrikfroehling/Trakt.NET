namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class TraktMovieAliasesRequest : AMovieRequest<ITraktMovieAlias>
    {
        public override string UriTemplate => "movies/{id}/aliases";
    }
}
