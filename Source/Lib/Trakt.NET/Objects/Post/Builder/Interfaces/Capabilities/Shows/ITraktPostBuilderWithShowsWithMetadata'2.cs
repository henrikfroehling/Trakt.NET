namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Basic;
    using Get.Shows;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithShowsWithMetadata<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?>> shows);

        TPostBuilder WithShowsAndMetadata(IEnumerable<Tuple<ITraktShow, ITraktMetadata, DateTime?, PostSeasons>> shows);
    }
}
