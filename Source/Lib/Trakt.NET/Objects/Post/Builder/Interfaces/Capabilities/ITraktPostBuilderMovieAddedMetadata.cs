namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Basic;
    using System;

    public interface ITraktPostBuilderMovieAddedMetadata<TPostBuilderAddMovie, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
