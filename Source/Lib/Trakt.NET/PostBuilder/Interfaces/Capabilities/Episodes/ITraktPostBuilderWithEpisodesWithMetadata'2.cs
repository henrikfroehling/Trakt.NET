namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderWithEpisodesWithMetadata<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisodesAndMetadata(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata>> episodes);

        TPostBuilder WithEpisodesAndMetadata(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>> episodes);

        TPostBuilder WithCollectedEpisodes(IEnumerable<Tuple<ITraktEpisode, DateTime?>> episodes);
    }
}
