namespace TraktNet.Objects.Post.Capabilities
{
    using Objects.Basic;
    using System;

    public interface ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithMetadata<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
