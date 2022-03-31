namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Shows;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithShowsWithMetadata<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, PostSeasons>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> shows);

        TPostBuilder WithCollectedShows(IEnumerable<Tuple<ITraktShow, DateTime?>> shows);

        TPostBuilder WithCollectedShows(IEnumerable<Tuple<ITraktShow, DateTime?, PostSeasons>> shows);
    }
}
