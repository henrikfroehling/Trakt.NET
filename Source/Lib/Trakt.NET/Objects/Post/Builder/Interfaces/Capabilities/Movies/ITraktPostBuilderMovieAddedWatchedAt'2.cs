namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;
    using System;

    public interface ITraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilderAddMovie, TPostObject>
    {
        TPostBuilderAddMovie WatchedAt(DateTime watchedAt);

        void SetCurrentMovie(ITraktMovie movie);
    }
}
