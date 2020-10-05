namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddMovie CollectedAt(DateTime collectedAt);
    }
}
