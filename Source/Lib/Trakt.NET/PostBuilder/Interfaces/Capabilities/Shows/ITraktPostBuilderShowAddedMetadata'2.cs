namespace TraktNet.PostBuilder
{
    using System;
    using TraktNet.Objects.Basic;

    public interface ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithMetadata<TPostBuilderAddShow, TPostObject>
    {
        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt);
    }
}
