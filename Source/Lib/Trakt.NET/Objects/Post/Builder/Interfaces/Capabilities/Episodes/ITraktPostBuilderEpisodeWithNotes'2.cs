namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithNotes<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithNotes<TPostBuilder, TPostObject>
    {
        TPostBuilder WithEpisodeWithNotes(ITraktEpisode episode, string notes);
    }
}
