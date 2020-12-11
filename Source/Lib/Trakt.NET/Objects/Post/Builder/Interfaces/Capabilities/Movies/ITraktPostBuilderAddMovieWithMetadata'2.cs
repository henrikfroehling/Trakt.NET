namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedMetadata<TPostBuilder, TPostObject> AddMovieAndMetadata(ITraktMovie movie);
    }
}
