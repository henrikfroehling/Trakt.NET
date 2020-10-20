namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Basic;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        List<PostBuilderObjectWithMetadataAndSeasons<ITraktShow, TSeasonCollection>> ShowsAndMetadataWithSeasonsCollection { get; }

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, TSeasonCollection seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, TSeasonCollection seasons);

        void SetCurrentShow(ITraktShow show);
    }
}
