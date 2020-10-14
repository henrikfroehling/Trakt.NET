namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAt<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderCollectedObject<ITraktShow>> CollectedShows { get; }

        TPostBuilderAddShow CollectedAt(DateTime collectedAt);

        void SetCurrentShow(ITraktShow show);
    }
}
