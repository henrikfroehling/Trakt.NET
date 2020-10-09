namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithCollectedAt<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt);
    }
}
