namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class TraktMovieAliasesRequest : ATraktMovieRequest<TraktMovieAlias>
    {
        public override string UriTemplate => "movies/{id}/aliases";
    }
}
