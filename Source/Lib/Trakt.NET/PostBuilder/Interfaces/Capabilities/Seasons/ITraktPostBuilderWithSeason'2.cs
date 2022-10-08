namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Seasons;

    public interface ITraktPostBuilderWithSeason<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithSeason(ITraktSeason season);
    }
}
