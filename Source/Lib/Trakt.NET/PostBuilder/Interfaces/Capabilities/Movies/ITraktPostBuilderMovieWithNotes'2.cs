namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;

    public interface ITraktPostBuilderMovieWithNotes<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithNotes<TPostBuilder, TPostObject>
    {
        TPostBuilder WithMovieWithNotes(ITraktMovie movie, string notes);
    }
}
