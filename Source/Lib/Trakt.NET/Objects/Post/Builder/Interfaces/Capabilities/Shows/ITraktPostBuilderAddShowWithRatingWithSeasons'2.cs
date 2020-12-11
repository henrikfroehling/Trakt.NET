﻿namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedRatingWithSeasons<TPostBuilder, TPostObject> AddRatedShowAndSeasons(ITraktShow show);
    }
}
