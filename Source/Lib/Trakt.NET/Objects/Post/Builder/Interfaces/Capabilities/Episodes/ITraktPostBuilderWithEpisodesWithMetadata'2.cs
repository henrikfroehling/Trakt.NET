﻿namespace TraktNet.Objects.Post.Capabilities
{
    using Basic;
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithEpisodesWithMetadata<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisodesAndMetadata(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata>> episodes);

        TPostBuilder WithEpisodesAndMetadata(IEnumerable<Tuple<ITraktEpisode, ITraktMetadata, DateTime?>> episodes);

        TPostBuilder WithCollectedEpisodes(IEnumerable<Tuple<ITraktEpisode, DateTime?>> episodes);
    }
}
