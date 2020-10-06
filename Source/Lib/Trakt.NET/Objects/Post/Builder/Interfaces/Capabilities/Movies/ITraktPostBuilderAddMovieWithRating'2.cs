namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithRating<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithMovie<ITraktPostBuilderAddMovieWithRating<TPostBuilder, TPostObject>, TPostObject>
          where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderMovieAddedRating<ITraktPostBuilderAddMovieWithRating<TPostBuilder, TPostObject>, TPostObject> AddMovie(ITraktMovie movie);
    }
}
