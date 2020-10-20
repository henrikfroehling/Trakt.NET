namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Movies;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderMovieAddedCollectedAt<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithCollectedAt<TPostBuilderAddMovie, TPostObject>
    {
        List<PostBuilderCollectedObject<ITraktMovie>> CollectedMovies { get; }

        TPostBuilderAddMovie CollectedAt(DateTime collectedAt);

        void SetCurrentMovie(ITraktMovie movie);
    }
}
