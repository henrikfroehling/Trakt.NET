namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Episodes;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithEpisode<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisode(ITraktEpisode episode);

        TPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);
    }
}
