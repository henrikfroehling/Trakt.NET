namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;

    public interface ITraktPostBuilderShowWithRatingWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderShowWithRatingWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection>
    {
        ITraktPostBuilderShowAddedRatingWithSeasonsCollection<TPostBuilder, TPostObject, TSeasonCollection> WithRatedShowAndSeasonsCollection(ITraktShow show);
    }
}
