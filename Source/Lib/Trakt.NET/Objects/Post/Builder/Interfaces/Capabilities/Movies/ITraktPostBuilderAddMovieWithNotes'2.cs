namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithNotes<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithNotes<TPostBuilder, TPostObject>
    {
        TPostBuilder AddMovieWithNotes(ITraktMovie movie, string notes);
    }
}
