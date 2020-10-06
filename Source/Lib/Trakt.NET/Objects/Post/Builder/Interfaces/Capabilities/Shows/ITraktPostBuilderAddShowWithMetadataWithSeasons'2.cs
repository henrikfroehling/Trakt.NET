namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilder, TPostObject>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilder, TPostObject>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedMetadataWithSeasons<ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilder, TPostObject>, TPostObject> AddShow(ITraktShow show);
    }
}
