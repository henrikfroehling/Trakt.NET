namespace TraktNet.PostBuilder
{
    using System;

    public interface ITraktPostBuilderMovieAddedRating<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderMovieWithRating<TPostBuilderAddMovie, TPostObject>
    {
        TPostBuilderAddMovie WithRating(int rating);

        TPostBuilderAddMovie WithRating(int rating, DateTime ratedAt);
    }
}
