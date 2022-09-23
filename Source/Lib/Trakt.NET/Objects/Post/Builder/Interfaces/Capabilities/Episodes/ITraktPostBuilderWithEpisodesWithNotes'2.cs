namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Episodes;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithEpisodesWithNotes<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisodesWithNotes(IEnumerable<Tuple<ITraktEpisode, string>> episodes);
    }
}
