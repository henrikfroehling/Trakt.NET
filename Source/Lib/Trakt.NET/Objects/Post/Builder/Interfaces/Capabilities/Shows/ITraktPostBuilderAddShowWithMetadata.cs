namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithMetadata<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithMetadata<TPostBuilder, TPostObject>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedMetadata<ITraktPostBuilderAddShowWithMetadata<TPostBuilder, TPostObject>, TPostObject> AddShow(ITraktShow movie);
    }
}
