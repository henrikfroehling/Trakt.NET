namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class TraktMovieAliasesRequest : ATraktMovieRequest<ITraktMovieAlias>
    {
        public override string UriTemplate => "movies/{id}/aliases";
    }
}
