namespace TraktNet.Objects.Post.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithCollectedAt<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt);
    }
}
