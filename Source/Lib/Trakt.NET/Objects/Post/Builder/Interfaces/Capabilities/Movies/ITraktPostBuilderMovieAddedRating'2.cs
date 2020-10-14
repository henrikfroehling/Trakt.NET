namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Movies;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderMovieAddedRating<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithRating<TPostBuilderAddMovie, TPostObject>
    {
        List<PostBuilderRatedObject<ITraktMovie>> MoviesAndRating { get; }

        TPostBuilderAddMovie WithRating(int rating);

        TPostBuilderAddMovie WithRating(int rating, DateTime ratedAt);

        void SetCurrentMovie(ITraktMovie movie);
    }
}
