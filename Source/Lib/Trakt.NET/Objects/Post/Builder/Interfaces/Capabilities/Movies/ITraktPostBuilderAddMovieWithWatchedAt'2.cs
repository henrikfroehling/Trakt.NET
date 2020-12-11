namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedWatchedAt<TPostBuilder, TPostObject> AddWatchedMovie(ITraktMovie movie);
    }
}
