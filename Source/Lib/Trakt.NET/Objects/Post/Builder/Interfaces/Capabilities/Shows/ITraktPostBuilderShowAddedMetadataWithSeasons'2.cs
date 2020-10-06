namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Basic;
    using System;

    public interface ITraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, out TPostObject> : ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int[] seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int[] seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int season, params int[] seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int season, params int[] seasons);
    }
}
