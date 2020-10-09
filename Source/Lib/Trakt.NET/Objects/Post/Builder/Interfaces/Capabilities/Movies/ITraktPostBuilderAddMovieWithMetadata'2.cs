﻿namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;

    public interface ITraktPostBuilderAddMovieWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderMovieAddedMetadata<TPostBuilder, TPostObject> AddMovieAndMetadata(ITraktMovie movie);
    }
}
