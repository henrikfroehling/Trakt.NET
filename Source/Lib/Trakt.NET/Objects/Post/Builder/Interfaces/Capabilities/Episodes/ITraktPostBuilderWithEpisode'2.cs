namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderWithEpisode<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisode(ITraktEpisode episode);
    }
}
