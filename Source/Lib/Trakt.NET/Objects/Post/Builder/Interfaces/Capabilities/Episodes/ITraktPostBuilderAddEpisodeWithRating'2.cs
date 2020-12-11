﻿namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderAddEpisodeWithRating<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddEpisodeWithRating<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderEpisodeAddedRating<TPostBuilder, TPostObject> AddRatedEpisode(ITraktEpisode episode);
    }
}
