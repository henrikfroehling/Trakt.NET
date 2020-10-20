namespace TraktNet.Objects.Post.Builder.Capabilities
{
    using Basic;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithShowsWithMetadata<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, DateTime?>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, PostSeasons>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, DateTime?, PostSeasons>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> shows);
    }
}
