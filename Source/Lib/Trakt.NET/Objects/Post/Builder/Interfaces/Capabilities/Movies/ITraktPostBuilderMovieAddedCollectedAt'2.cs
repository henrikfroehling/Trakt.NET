namespace TraktNet.Objects.Post.Capabilities
{
    using System;

    public interface ITraktPostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithCollectedAt<TPostBuilderAddMovie, TPostObject>
    {
        TPostBuilderAddMovie CollectedAt(DateTime collectedAt);
    }
}
