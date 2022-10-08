namespace TraktNet.PostBuilder
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Shows;

    public interface ITraktPostBuilderWithShowsWithMetadata<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, PostSeasonsOld>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasonsOld>> shows);

        TPostBuilder WithCollectedShows(IEnumerable<Tuple<ITraktShow, DateTime?>> shows);

        TPostBuilder WithCollectedShows(IEnumerable<Tuple<ITraktShow, DateTime?, PostSeasonsOld>> shows);
    }
}
