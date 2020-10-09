﻿namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedMetadata<TPostBuilder, TPostObject> AddShowAndMetadata(ITraktShow show);
    }
}
