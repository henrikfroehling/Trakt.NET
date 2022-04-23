namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderShowWithMetadata<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithMetadata<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedMetadata<TPostBuilder, TPostObject> WithShowAndMetadata(ITraktShow show);
    }
}
