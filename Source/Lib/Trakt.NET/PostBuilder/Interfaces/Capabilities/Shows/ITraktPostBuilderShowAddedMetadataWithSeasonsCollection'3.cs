namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Basic;

    public interface ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, in TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, TSeasonCollection seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, TSeasonCollection seasons);
    }
}
