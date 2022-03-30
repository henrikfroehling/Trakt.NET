namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderMovieWithWatchedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithWatchedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedWatchedAt<TPostBuilder, TPostObject> WithWatchedMovie(ITraktMovie movie);
    }
}
