namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Basic;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, IEnumerable<int>>> ShowsAndMetadataWithSeasons { get; }

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int[] seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int[] seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, int season, params int[] seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, int season, params int[] seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
