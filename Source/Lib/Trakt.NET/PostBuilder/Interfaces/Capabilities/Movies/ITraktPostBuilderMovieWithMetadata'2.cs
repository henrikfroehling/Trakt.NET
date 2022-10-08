namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderMovieWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedMetadata<TPostBuilder, TPostObject> WithMovieAndMetadata(ITraktMovie movie);
    }
}
