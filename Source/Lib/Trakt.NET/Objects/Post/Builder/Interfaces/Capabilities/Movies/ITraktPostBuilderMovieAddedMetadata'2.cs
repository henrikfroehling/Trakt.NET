﻿namespace TraktNet.Objects.Post.Capabilities
{
    using Basic;
    using System;

    public interface ITraktPostBuilderMovieAddedMetadata<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithMetadata<TPostBuilderAddMovie, TPostObject>
    {
        TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
