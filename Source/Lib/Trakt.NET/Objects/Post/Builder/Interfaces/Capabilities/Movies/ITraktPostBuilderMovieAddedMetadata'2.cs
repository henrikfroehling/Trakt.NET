namespace TraktNet.Objects.Post.Capabilities
{
    using Objects.Basic;
    using System;

    public interface ITraktPostBuilderMovieAddedMetadata<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithMetadata<TPostBuilderAddMovie, TPostObject>
    {
        TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
