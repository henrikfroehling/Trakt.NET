namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithMetadata<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithMetadata<TPostBuilder, TPostObject>, TPostObject>
          where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderMovieAddedMetadata<ITraktPostBuilderAddMovieWithMetadata<TPostBuilder, TPostObject>, TPostObject> AddMovie(ITraktMovie movie);
    }
}
