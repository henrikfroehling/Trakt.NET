namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Basic;
    using Get.Movies;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderMovieAddedMetadata<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithMetadata<TPostBuilderAddMovie, TPostObject>
    {
        List<PostBuilderObjectWithMetadata<ITraktMovie>> MoviesAndMetadata { get; }

        TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddMovie WithMetadata(ITraktMetadata metadata, DateTime collectedAt);

        void SetCurrentMovie(ITraktMovie movie);
    }
}
