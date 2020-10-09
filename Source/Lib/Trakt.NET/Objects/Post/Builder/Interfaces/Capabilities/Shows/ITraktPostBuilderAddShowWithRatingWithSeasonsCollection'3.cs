namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilder, TPostObject, in TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderAddShowWithRatingWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> AddRatedShowAndSeasonsCollection(ITraktShow show);
    }
}
