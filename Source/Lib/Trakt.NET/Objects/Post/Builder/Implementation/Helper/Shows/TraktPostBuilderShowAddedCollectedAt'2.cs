namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAt<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedCollectedAt()
        {
        }

        public TPostBuilderAddShow CollectedAt(DateTime collectedAt)
        {
            throw new NotImplementedException();
        }
    }
}
