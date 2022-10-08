﻿namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderShowWithCollectedAt<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithCollectedAt<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedCollectedAt<TPostBuilder, TPostObject> WithCollectedShow(ITraktShow show);
    }
}