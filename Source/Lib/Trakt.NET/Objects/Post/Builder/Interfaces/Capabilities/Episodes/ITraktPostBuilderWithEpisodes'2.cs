namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Get.Episodes;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithEpisodes<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);
    }
}
