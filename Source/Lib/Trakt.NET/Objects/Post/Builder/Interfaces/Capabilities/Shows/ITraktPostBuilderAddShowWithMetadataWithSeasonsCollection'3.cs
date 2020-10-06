namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        : ITraktPostBuilder<TPostObject>,
          ITraktPostBuilderWithShow<ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<ITraktPostBuilderAddShowWithMetadataWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>, TPostObject, TSeasonCollection> AddShow(ITraktShow show);
    }
}
