namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithWatchedAtWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        internal TraktPostBuilderShowAddedWatchedAtWithSeasonsCollection()
        {
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt, TSeasonCollection seasons)
        {
            throw new NotImplementedException();
        }
    }
}
