namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderShowWithMetadataWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithMetadataWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedMetadataWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> WithShowAndMetadataAndSeasonsCollection(ITraktShow show);
    }
}
