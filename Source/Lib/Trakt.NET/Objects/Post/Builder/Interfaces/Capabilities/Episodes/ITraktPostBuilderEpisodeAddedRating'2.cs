namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderEpisodeAddedRating<TPostBuilderAddEpisode, out TPostObject>
        where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithRating<TPostBuilderAddEpisode, TPostObject>
    {
        TPostBuilderAddEpisode WithRating(int rating);

        TPostBuilderAddEpisode WithRating(int rating, DateTime ratedAt);
    }
}
