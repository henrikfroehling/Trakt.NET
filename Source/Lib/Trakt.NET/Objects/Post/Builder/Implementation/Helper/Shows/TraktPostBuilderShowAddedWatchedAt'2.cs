namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedWatchedAt<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithWatchedAt<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedWatchedAt()
        {
        }

        public TPostBuilderAddShow WatchedAt(DateTime watchedAt)
        {
            throw new NotImplementedException();
        }
    }
}
