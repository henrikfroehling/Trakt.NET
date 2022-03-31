namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderShowWithMetadataWithSeasons<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithMetadataWithSeasons<TPostBuilder, TPostObject>
    {
        ITraktPostBuilderShowAddedMetadataWithSeasons<TPostBuilder, TPostObject> WithShowAndMetadataAndSeasons(ITraktShow show);
    }
}
