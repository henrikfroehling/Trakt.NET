namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderMovieWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedMetadata<TPostBuilder, TPostObject> WithMovieAndMetadata(ITraktMovie movie);
    }
}
