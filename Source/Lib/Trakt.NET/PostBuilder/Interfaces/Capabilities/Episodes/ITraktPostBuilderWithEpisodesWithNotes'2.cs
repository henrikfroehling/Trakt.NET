namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Get.Episodes;

    public interface ITraktPostBuilderWithEpisodesWithNotes<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithEpisodesWithNotes(IEnumerable<Tuple<ITraktEpisode, string>> episodes);
    }
}
