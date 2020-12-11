﻿namespace TraktNet.Objects.Post.Capabilities
{
    public interface ITraktPostBuilderShowAddedSeasons<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithSeasons<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithSeasons(int[] seasons);

        TPostBuilderAddShow WithSeasons(int season, params int[] seasons);
    }
}
