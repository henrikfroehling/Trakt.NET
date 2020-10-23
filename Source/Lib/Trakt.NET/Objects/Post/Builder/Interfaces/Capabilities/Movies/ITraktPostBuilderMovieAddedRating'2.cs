namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using System;

    public interface ITraktPostBuilderMovieAddedRating<TPostBuilderAddMovie, out TPostObject>
        where TPostBuilderAddMovie : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddMovieWithRating<TPostBuilderAddMovie, TPostObject>
    {
        TPostBuilderAddMovie WithRating(int rating);

        TPostBuilderAddMovie WithRating(int rating, DateTime ratedAt);
    }
}
