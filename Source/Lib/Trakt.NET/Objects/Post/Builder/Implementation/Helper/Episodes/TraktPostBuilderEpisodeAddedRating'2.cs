namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderEpisodeAddedRating<TPostBuilderAddEpisode, TPostObject>
        : ITraktPostBuilderEpisodeAddedRating<TPostBuilderAddEpisode, TPostObject>
          where TPostBuilderAddEpisode : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithRating<TPostBuilderAddEpisode, TPostObject>
    {
        internal TraktPostBuilderEpisodeAddedRating()
        {
        }

        public TPostBuilderAddEpisode WithRating(int rating)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddEpisode WithRating(int rating, DateTime ratedAt)
        {
            throw new NotImplementedException();
        }
    }
}
