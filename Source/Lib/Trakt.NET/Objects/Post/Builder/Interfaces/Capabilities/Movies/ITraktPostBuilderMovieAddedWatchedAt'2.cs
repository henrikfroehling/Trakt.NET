namespace TraktNet.Objects.Post.Capabilities
{
    using System;

    public interface ITraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithWatchedAt<TPostBuilderAddMovie, TPostObject>
    {
        TPostBuilderAddMovie WatchedAt(DateTime watchedAt);
    }
}
