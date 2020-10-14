namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithWatchedAt<TPostBuilderAddMovie, TPostObject>
    {
        List<PostBuilderWatchedObject<ITraktMovie>> WatchedMovies { get; }

        TPostBuilderAddMovie WatchedAt(DateTime watchedAt);

        void SetCurrentMovie(ITraktMovie movie);
    }
}
