namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
        : ITraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        internal TraktPostBuilderShowAddedMetadataWithSeasons()
        {
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int[] seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int[] seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int season, params int[] seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int season, params int[] seasons)
        {
            throw new NotImplementedException();
        }
    }
}
