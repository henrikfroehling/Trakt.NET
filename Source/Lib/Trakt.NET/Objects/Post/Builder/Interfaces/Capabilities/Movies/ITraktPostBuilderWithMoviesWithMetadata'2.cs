namespace TraktNet.Objects.Post.Builder.Interfaces.Capabilities
{
    using Basic;
    using Get.Movies;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithMoviesWithMetadata<TPostBuilder, TPostObject>
        : ITraktPostBuilderWithMovie<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMovies(IEnumerable<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> movies);
    }
}
