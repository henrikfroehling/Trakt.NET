namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderMovieWithWatchedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithWatchedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedWatchedAt<TPostBuilder, TPostObject> WithWatchedMovie(ITraktMovie movie);
    }
}
