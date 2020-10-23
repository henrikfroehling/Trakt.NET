namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAt<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt);
    }
}
