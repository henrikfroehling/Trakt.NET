namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadata<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedMetadata()
        {
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt)
        {
            throw new NotImplementedException();
        }
    }
}
