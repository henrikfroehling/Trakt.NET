namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderWithEpisode<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisode(ITraktEpisode episode);
    }
}
