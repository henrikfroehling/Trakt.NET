namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderMovieAddedWatchedAt<TPostBuilderAddMovie, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddMovie WatchedAt(DateTime watchedAt);
    }
}
