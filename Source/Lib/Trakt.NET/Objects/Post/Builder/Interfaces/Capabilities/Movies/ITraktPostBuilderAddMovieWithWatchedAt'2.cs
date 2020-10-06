namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilder, TPostObject>, TPostObject>
          where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderMovieAddedWatchedAt<ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilder, TPostObject>, TPostObject> AddMovie(ITraktMovie movie);
    }
}
