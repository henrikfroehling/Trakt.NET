namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderMovieWithCollectedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithCollectedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedCollectedAt<TPostBuilder, TPostObject> WithCollectedMovie(ITraktMovie movie);
    }
}
