namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderEpisodeWithNotes<TPostBuilder, TPostObject>
        where TPostBuilder : ITraktPostBuilder<TPostObject>, ITraktPostBuilderEpisodeWithNotes<TPostBuilder, TPostObject>
    {
        TPostBuilder WithEpisodeWithNotes(ITraktEpisode episode, string notes);
    }
}
