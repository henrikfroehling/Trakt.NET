﻿namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilder, TPostObject, in TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> AddShowAndSeasonsCollection(ITraktShow show);
    }
}
