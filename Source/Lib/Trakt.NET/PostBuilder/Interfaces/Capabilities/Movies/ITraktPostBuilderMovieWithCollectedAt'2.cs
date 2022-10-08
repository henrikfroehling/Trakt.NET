namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderMovieWithCollectedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithCollectedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedCollectedAt<TPostBuilder, TPostObject> WithCollectedMovie(ITraktMovie movie);
    }
}
