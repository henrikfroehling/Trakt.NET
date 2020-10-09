namespace TraktNet.Objects.Post.Builder.Implementation.Helper
{
    using Basic;
    using Interfaces;
    using Interfaces.Capabilities;
    using System;

    internal class TraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
        : ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
          where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>,
                                      ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        internal TraktPostBuilderShowAddedMetadataWithSeasonsCollection()
        {
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, TSeasonCollection seasons)
        {
            throw new NotImplementedException();
        }

        public TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, TSeasonCollection seasons)
        {
            throw new NotImplementedException();
        }
    }
}
