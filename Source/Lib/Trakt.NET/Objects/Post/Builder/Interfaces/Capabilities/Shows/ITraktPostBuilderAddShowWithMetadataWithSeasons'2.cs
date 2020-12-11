namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithMetadataWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilder, TPostObject> AddShowAndMetadataAndSeasons(ITraktShow show);
    }
}
