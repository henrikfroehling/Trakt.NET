namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithRating(int rating, TSeasonCollection seasons);

        TPostBuilderAddShow WithRating(int rating, DateTime ratedAt, TSeasonCollection seasons);
    }
}
