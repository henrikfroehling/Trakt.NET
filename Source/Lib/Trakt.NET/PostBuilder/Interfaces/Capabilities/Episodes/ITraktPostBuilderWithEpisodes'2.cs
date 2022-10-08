namespace TraktNet.PostBuilder
{
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderWithEpisodes<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisodes(IEnumerable<ITraktEpisode> episodes);
    }
}
