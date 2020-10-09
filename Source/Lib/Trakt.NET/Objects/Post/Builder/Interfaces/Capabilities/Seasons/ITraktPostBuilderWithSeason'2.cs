namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Seasons;

    public interface ITraktPostBuilderWithSeason<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithSeason(ITraktSeason season);
    }
}
