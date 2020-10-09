namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Basic;
    using System;

    public interface ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadata<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
