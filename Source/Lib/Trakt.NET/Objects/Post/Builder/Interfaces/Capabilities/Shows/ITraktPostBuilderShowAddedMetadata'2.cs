namespace TraktNet.Objects.Post.Capabilities
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
