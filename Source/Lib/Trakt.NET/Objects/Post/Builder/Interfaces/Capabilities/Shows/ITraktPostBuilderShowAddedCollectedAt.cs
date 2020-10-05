namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using System;

    public interface ITraktPostBuilderShowAddedCollectedAt<TPostBuilderAddShow, out TPostObject> : ITraktPostBuilder<TPostObject>
    {
        TPostBuilderAddShow CollectedAt(DateTime collectedAt);
    }
}
