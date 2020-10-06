namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Basic;
    using System;

    public interface ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection> : ITraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, TSeasonCollection seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, TSeasonCollection seasons);
    }
}
