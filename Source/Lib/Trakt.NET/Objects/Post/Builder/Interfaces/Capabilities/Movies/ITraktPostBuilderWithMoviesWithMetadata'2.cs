namespace TraktNet.Objects.Post.Capabilities
{
    using Get.Movies;
    using Objects.Basic;
    using System;
    using System.Collections.Generic;

    public interface ITraktPostBuilderWithMoviesWithMetadata<TPostBuilder, TPostObject> where TPostBuilder : ITraktPostBuilder<TPostObject>
    {
        TPostBuilder WithMoviesAndMetadata(IEnumerable<Tuple<ITraktMovie, ITraktMetadata>> movies);

        TPostBuilder WithMoviesAndMetadata(IEnumerable<Tuple<ITraktMovie, ITraktMetadata, DateTime?>> movies);

        TPostBuilder WithCollectedMovies(IEnumerable<Tuple<ITraktMovie, DateTime?>> movies);
    }
}
