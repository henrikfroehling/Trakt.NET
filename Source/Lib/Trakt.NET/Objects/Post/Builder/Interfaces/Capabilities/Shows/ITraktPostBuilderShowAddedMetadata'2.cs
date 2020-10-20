namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Basic;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderShowAddedMetadata<TPostBuilderAddShow, out TPostObject>
        where TPostBuilderAddShow : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadata<TPostBuilderAddShow, TPostObject>
    {
        List<PostBuilderObjectWithMetadata<ITraktShow>> ShowsAndMetadata { get; }

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata);

        TPostBuilderAddShow WithMetadata(ITraktMetadata metadata, DateTime collectedAt);

        void SetCurrentShow(ITraktShow show);
    }
}
