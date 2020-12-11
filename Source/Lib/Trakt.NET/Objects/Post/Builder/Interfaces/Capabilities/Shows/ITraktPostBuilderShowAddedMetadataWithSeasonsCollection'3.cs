﻿namespace TraktNet.Objects.Post.Capabilities
{
    using Basic;
    using System;

    public interface ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilderAddShow, out TPostObject, in TSeasonCollection>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<TPostBuilderAddShow, TPostObject, TSeasonCollection>
    {
        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, TSeasonCollection seasons);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt, TSeasonCollection seasons);
    }
}
