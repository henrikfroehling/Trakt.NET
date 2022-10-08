namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderMovieWithRating<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithRating<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedRating<TPostBuilder, TPostObject> WithRatedMovie(ITraktMovie movie);
    }
}
