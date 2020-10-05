namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithCollectedAt<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithCollectedAt<TPostBuilder, TPostObject>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderMovieAddedCollectedAt<ITraktPostBuilderAddMovieWithCollectedAt<TPostBuilder, TPostObject>, TPostObject> AddMovie(ITraktMovie movie);
    }
}
