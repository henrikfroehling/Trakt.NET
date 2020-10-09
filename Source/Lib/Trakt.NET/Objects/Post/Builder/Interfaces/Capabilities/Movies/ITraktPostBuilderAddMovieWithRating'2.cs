namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithRating<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithRating<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedRating<TPostBuilder, TPostObject> AddRatedMovie(ITraktMovie movie);
    }
}
