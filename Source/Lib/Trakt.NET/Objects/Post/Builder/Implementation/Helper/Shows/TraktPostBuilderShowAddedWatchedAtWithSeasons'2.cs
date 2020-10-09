namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAtWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedWatchedAtWithSeasons()
        {
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, int[] seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, int season, params int[] seasons)
        {
            throw new NotImplementedException();
        }
    }
}
